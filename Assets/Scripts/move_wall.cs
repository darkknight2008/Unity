using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_wall : MonoBehaviour {

    public Transform rd;
    private int distance;
    public GameObject pl;

    // Use this for initialization
    void Start () {
        rd = GetComponent<Transform >();
    }

    // Update is called once per frame
    private void Update()
    {
        float dis= Vector3.Distance(pl.transform.position, rd.transform.position);
        Debug.Log(dis);
        if (dis<4.0)
        {
            distance = 4;
            rd.transform.position = (rd.transform.position - pl.transform.position).normalized * distance + pl.transform.position;
        }
    }
}

