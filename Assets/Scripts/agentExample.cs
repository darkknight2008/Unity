using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using UnityEngine;
using UnityEngine.AI;

using System;

public class agentExample : MonoBehaviour
{

    NavMeshAgent agent;

    public float error;

    public float thresh;

    private bool activate;

    private Vector3 rand;
    private Vector3 change;

    private GameObject[] agents;

    private float d;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        activate = false;
        agents = GameObject.FindGameObjectsWithTag("Navagent");
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject other in agents)
        {
            if(!agent.Equals(other.GetComponent<NavMeshAgent>()))
            {
                d = Vector3.Distance(agent.destination, other.transform.position);
                if (d <= thresh)
                {
                    rand = UnityEngine.Random.onUnitSphere;
                    change = rand * error;
                    agent.SetDestination(agent.destination + change);
                    break;
                }
            }
        }
    }

    public void MoveTo(Vector3 p)
    {
        if (activate)
        {
            agent.SetDestination(p);
        }
    }

    public void SwitchStatus()
    {
        activate = !activate;
        if (activate)
        {
            agent.transform.localScale = Vector3.Scale(agent.transform.localScale, new Vector3(1.25f, 1.25f, 1.25f));
        }
        else
        {
            agent.transform.localScale = Vector3.Scale(agent.transform.localScale, new Vector3(0.8f, 0.8f, 0.8f));
        }
    }

    public void TrunOff()
    {
        if (activate)
        { 
            agent.transform.localScale = Vector3.Scale(agent.transform.localScale, new Vector3(0.8f, 0.8f, 0.8f));
        }
        activate = false;
    }

}