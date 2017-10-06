using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agentSelecter : MonoBehaviour {
    
    private GameObject[] agents;
    private GameObject[] monsters;

    // Use this for initialization
    void Start () {
        agents = GameObject.FindGameObjectsWithTag("Navagent");
        monsters = GameObject.FindGameObjectsWithTag("Monster");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MoveTo(Vector3 p)
    {
        foreach (GameObject a in agents)
        {
            a.GetComponent<agentExample>().MoveTo(p);
        }
        foreach (GameObject a in monsters)
        {
            if (a.GetComponent<monster2>().activate)
            {
                StartCoroutine(a.GetComponent<monster2>().MoveTo(p));
            }
        }
    }

    public void DeselectAll()
    {
        foreach (GameObject a in agents)
        {
            a.GetComponent<agentExample>().TrunOff();
        }
        foreach (GameObject a in monsters)
        {
            a.GetComponent<monster2>().TrunOff();
        }
    }

}
