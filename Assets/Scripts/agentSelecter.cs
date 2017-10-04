using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agentSelecter : MonoBehaviour {
    
    private GameObject[] agents;

    // Use this for initialization
    void Start () {
        agents = GameObject.FindGameObjectsWithTag("Navagent");
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

    }

    public void DeselectAll()
    {
        foreach (GameObject a in agents)
        {
            a.GetComponent<agentExample>().TrunOff();
        }
    }

}
