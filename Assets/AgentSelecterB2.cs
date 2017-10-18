using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSelecterB2 : MonoBehaviour {

    private Vector3 p;

    private AgentControllerB2 targetscript;

    private GameObject[] agents;

    // Use this for initialization
    void Start()
    {
        agents = GameObject.FindGameObjectsWithTag("Navagent");
        p = new Vector3(-5.0f, 0.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetButtonDown("Fire2"))
        {
            if (Physics.Raycast(ray, out hit, 1000))
            {
                p = hit.point;
                foreach (GameObject agent in agents)
                {
                    agent.GetComponent<AgentControllerB2>().MoveTo(p);
                }
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.CompareTag("Navagent"))
                {
                    hit.collider.GetComponent<AgentControllerB2>().SwitchStatus();
                }
                else if (hit.collider.CompareTag("SpeedLight"))
                {
                    hit.collider.GetComponentInParent<AgentControllerB2>().SwitchSpeed();
                }
                else
                {
                    foreach (GameObject agent in agents)
                    {
                        agent.GetComponent<AgentControllerB2>().TrunOff();
                    }
                }
            }
        }
    }
}
