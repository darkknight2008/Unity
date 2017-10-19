using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentControllerB2 : MonoBehaviour
{

    NavMeshAgent agent;
    Animator anim;
    public float error;
    public float thresh;
    public Material normalMaterial;
    public Material speedUpMaterial;
    public float walkSpeed;
    public float runSpeed;
    public float angelScale;

    public float w;

    public bool activate;
    public float offset;
    private bool isWalking;
    private Vector3 rand;
    private Vector3 change;

    private GameObject[] agents;
    private GameObject speedLight;

    private float d;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.baseOffset = offset;
        speedLight = transform.GetChild(1).gameObject;
        agents = GameObject.FindGameObjectsWithTag("Navagent");
        anim = transform.GetChild(0).gameObject.GetComponent<Animator>();

        activate = false;
        agent.speed = walkSpeed;
        isWalking = true;
        speedLight.GetComponent<Renderer>().material = normalMaterial;
        speedLight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject other in agents)
        {
            if (!agent.Equals(other.GetComponent<UnityEngine.AI.NavMeshAgent>()))
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
        anim.SetFloat("v", agent.velocity.magnitude);
        w = GetComponent<Rigidbody>().angularVelocity.magnitude * angelScale;
        anim.SetFloat("angle", w);
        anim.SetBool("jump", agent.isOnOffMeshLink);
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
            speedLight.SetActive(true);
        }
        else
        {
            speedLight.SetActive(false);
        }
    }

    public void TrunOff()
    {
        if (activate)
        {
            speedLight.SetActive(false);
        }
        activate = false;
    }

    public void SwitchSpeed()
    {
        isWalking = !isWalking;
        if (isWalking)
        {
            agent.speed = walkSpeed;
            speedLight.GetComponent<Renderer>().material = normalMaterial;
        }
        else
        {
            agent.speed = runSpeed;
            speedLight.GetComponent<Renderer>().material = speedUpMaterial;
        }
    }

}