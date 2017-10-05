using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using UnityEngine;
using UnityEngine.AI;

using System;

public class tsj_monster : MonoBehaviour
{
    NavMeshAgent agent;

    NavMeshObstacle obs;

    public bool activate;

    private NavMeshPath path;

    private Vector3 v;
    private Vector3 destination;

    public float agent_time;
    public float obs_time;
    public float mid_time;

    private float atc;
    private float otc;
    private float mtc1;
    private float mtc2;
    private string state;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        obs = GetComponent<NavMeshObstacle>();
        activate = false;

        atc = 0;
        otc = obs_time;
        mtc1 = 0;
        mtc2 = 0;
        agent.enabled = false;
        obs.enabled = true;
        state = "obs";

        v = new Vector3(0.0f, 0.0f, 0.0f);
        destination = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (state == "agent")
        {
            atc -= Time.deltaTime;
            if (atc <= 0)
            {
                v = agent.velocity;
                destination = agent.destination;
                //path = agent.path;
                agent.enabled = false;
                state = "m1";
                mtc1 = mid_time;
            }
        }
        else if (state == "m1")
        {
            transform.position = transform.position + v * Time.deltaTime;
            mtc1 -= Time.deltaTime;
            if (mtc1 <= 0)
            {
                obs.enabled = true;
                state = "obs";
                otc = obs_time;
            }
        }
        else if (state == "obs")
        {
            transform.position = transform.position + v * Time.deltaTime;
            otc -= Time.deltaTime;
            if (otc <= 0)
            {
                obs.enabled = false;
                state = "m2";
                mtc2 = mid_time;
            }
        }
        else
        {
            transform.position = transform.position + v * Time.deltaTime;
            mtc2 -= Time.deltaTime;
            if (mtc2 <= 0)
            {
                agent.enabled = true;
                agent.velocity = v;
                agent.SetDestination(destination);
                state = "agent";
                atc = agent_time;
            }
        }
    }

   

    public void MoveTo(Vector3 p)
    {
        if (agent.enabled)
        {
            agent.SetDestination(p);
        }
        else
        {
            destination = p;
        }
    }

    public void SwitchStatus()
    {
        activate = !activate;
        if (activate)
        {
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1.25f, 1.25f, 1.25f));
        }
        else
        {
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(0.8f, 0.8f, 0.8f));
        }
    }

    public void TrunOff()
    {
        if (activate)
        {
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(0.8f, 0.8f, 0.8f));
        }
        activate = false;
    }

}