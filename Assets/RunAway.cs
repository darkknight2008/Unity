using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunAway : MonoBehaviour {

    public GameObject[] destinations;
    private GameObject[] agents;
    private NavMeshAgent agent;

	// Use this for initialization
	void Start () {
        agents = GameObject.FindGameObjectsWithTag("Navagent");
        for (int i = 0; i < agents.Length; i++)
        {
            agents[i].GetComponent<NavMeshAgent>().SetDestination(destinations[i%3].transform.position);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
