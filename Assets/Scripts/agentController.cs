using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class agentController : MonoBehaviour {

    private Vector3 p;

    public agentSelecter selecter;

    private agentExample targetscript;

   // private GameObject crate;

    // Use this for initialization
    void Start () {
        p = new Vector3(-15.0f, 6.0f, 15.0f);
    }
	
	// Update is called once per frame
	void Update () {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetButtonDown("Fire2"))
        {
            if (Physics.Raycast(ray, out hit, 1000))
            {
                p = hit.point;
                selecter.MoveTo(p);
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.CompareTag("Navagent"))
                {
                    targetscript = hit.collider.GetComponent<agentExample>();
                    targetscript.SwitchStatus();
                }
                else
                {
                    selecter.DeselectAll();
                }
               // if (hit.collider.CompareTag("mobile"))
               // {
               //     crate = hit.collider.GetComponent<GameObject>();
               //     targetscript.SwitchStatus();
               // }
            }
        }

    }
}
