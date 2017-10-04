using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_away : MonoBehaviour {

   
    private int distance;
    public GameObject pl;

    // Use this for initialization
    void Start () {
       
    }

    // Update is called once per frame
    private void Update()
    {
        float dis= Vector3.Distance(pl.transform.position, transform.position);
        //Debug.Log(dis);
        if (dis<4.0)
        {
            distance = 4;
            transform.position = (transform.position - pl.transform.position).normalized * distance + pl.transform.position;
        }
    }
}

