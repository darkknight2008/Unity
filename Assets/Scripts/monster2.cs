using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using UnityEngine;
using UnityEngine.AI;

using System;

public class monster2 : MonoBehaviour
{
    private NavMeshAgent agent;
    private NavMeshObstacle obs;

    public bool activate;
    public float delay;
    public float velocity;
    public float height;
    public float pickScale;

    private bool move;
    private Vector3[] corners;
    private int index;
    NavMeshHit hit;
    private Vector3 vForY;
    private Vector3 pos;
    private Vector3 increase;
    private Vector3 decrease;

    private NavMeshPath path;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        obs = GetComponent<NavMeshObstacle>();
        activate = false;
        move = false;

        path = new NavMeshPath();
        vForY = new Vector3(0.0f, height, 0.0f);

        increase = new Vector3(pickScale, 1.0f, pickScale);
        decrease = new Vector3(1/pickScale, 1.0f, 1/pickScale);
    }

    // Update is called once per frame
    void Update()
    {
        if (move && index < corners.Length)
        {
            if (Vector3.Distance(corners[index] + vForY, transform.position) > Time.deltaTime * velocity)
            {
                pos = Vector3.MoveTowards(transform.position, corners[index] + vForY, Time.deltaTime * velocity);
            }
            else
            {
                pos = corners[index] + vForY;
                index += 1;
                if (index == corners.Length)
                {
                    move = false;
                }
            }
            transform.position = pos;
        }
    }

    public IEnumerator MoveTo(Vector3 p)
    {

        obs.enabled = false;

        yield return new WaitForSeconds(delay);

        move = false;
        bool flag = NavMesh.CalculatePath(transform.position, p, NavMesh.AllAreas, path);

        yield return new WaitForSeconds(delay);

        if (flag)
        {
            corners = path.corners;
            index = 0;
            move = true;
        }

        obs.enabled = true;
    }

    public void SwitchStatus()
    {
        activate = !activate;
        if (activate)
        {
            transform.localScale = Vector3.Scale(transform.localScale, increase);
            obs.radius = obs.radius / pickScale;
        }
        else
        {
            transform.localScale = Vector3.Scale(transform.localScale, decrease);
            obs.radius = obs.radius * pickScale;
        }
    }

    public void TrunOff()
    {
        if (activate)
        {
            transform.localScale = Vector3.Scale(transform.localScale, decrease);
            obs.radius = obs.radius * pickScale;
        }
        activate = false;
    }

}