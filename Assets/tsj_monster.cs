using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using UnityEngine;
using UnityEngine.AI;

using System;

public class tsj_monster : MonoBehaviour
{
    private NavMeshAgent agent;
    private NavMeshObstacle obs;

    public bool activate;

    public float agent_time;
    public float obs_time;
    public float mid_time;
    public float delay;
    public float velocity;
    public float height;

    private float atc;
    private float otc;
    private float mtc1;
    private float mtc2;
    private string state;
    private float timeOnPath;
    private bool move;
    private Vector3[] corners;
    private int index;
    NavMeshHit hit;
    private Vector3 vForY;
    private Vector3 pos;

    private NavMeshPath path;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        obs = GetComponent<NavMeshObstacle>();
        activate = false;

        atc = agent_time;
        otc = 0;
        mtc1 = 0;
        mtc2 = 0;
        timeOnPath = 0.0f;
        move = false;
        agent.enabled = false;
        obs.enabled = true;
        state = "agent";
        agent.autoRepath = false;
        agent.autoBraking = false;

        path = new NavMeshPath();

        vForY = new Vector3(0.0f, height, 0.0f);


    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey("space"))
        //{
        //    obs.enabled = true;
        //}

        //if (move && corners.Length > 0)
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, corners[corners.Length - 1], Time.deltaTime * velocity);
        //    throw new System.ArgumentException("Corners size", corners.Length.ToString());
        //}

        if (move && index < corners.Length)
        {
            timeOnPath += Time.deltaTime;
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


        //if (state == "agent")
        //{
        //    atc -= Time.deltaTime;
        //    if (atc <= 0)
        //    {
        //        agent.autoRepath = false;
        //        state = "m1";
        //        mtc1 = mid_time;
        //    }
        //}
        //else if (state == "m1")
        //{
        //    //transform.position = transform.position + v * Time.deltaTime;
        //    mtc1 -= Time.deltaTime;
        //    if (mtc1 <= 0)
        //    {
        //        obs.enabled = true;
        //        state = "obs";
        //        otc = obs_time;
        //    }
        //}
        //else if (state == "obs")
        //{
        //    //transform.position = transform.position + v * Time.deltaTime;
        //    otc -= Time.deltaTime;
        //    if (otc <= 0)
        //    {
        //        obs.enabled = false;
        //        state = "m2";
        //        mtc2 = mid_time;
        //    }
        //}
        //else
        //{
        //    //transform.position = transform.position + v * Time.deltaTime;
        //    mtc2 -= Time.deltaTime;
        //    if (mtc2 <= 0)
        //    {
        //        agent.autoRepath = true;
        //        state = "agent";
        //        atc = agent_time;
        //    }
        //}
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

        //corners = path.corners;

        //yield return new WaitForSeconds(delay);

        ////throw new System.ArgumentException("Corners size", corners.Length.ToString());
        //timeOnPath = 0;
        //index = 0;
        //move = true;

        //obs.enabled = true;

        //yield return new WaitForSeconds(delay);

        //obs.enabled = false;

        //yield return new WaitForSeconds(delay);

        //agent.enabled = true;

        //agent.CalculatePath(p, path);

        //yield return new WaitForSeconds(delay);

        //agent.SetPath(path);

        //yield return new WaitForSeconds(delay);

        //obs.enabled = true;

        //agent.SetDestination(p);
    }

    public void SwitchStatus()
    {
        activate = !activate;
        if (activate)
        {
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1.25f, 1.25f, 1.25f));
            obs.radius = obs.radius * 0.8f;
        }
        else
        {
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(0.8f, 0.8f, 0.8f));
            obs.radius = obs.radius * 1.25f;
        }
    }

    public void TrunOff()
    {
        if (activate)
        {
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(0.8f, 0.8f, 0.8f));
            obs.radius = obs.radius * 1.25f;
        }
        activate = false;
    }

}