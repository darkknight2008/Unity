using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    private Transform parent;
    private Vector3 startPositionP;
    private Vector3 startPositionC;

    void Start()
    {
        parent = transform.parent.gameObject.transform;
        //parent = GameObject.FindGameObjectWithTag("Player").transform;
        startPositionP = parent.transform.position;
        startPositionC = transform.position;
    }

    void Update()
    {
        transform.position = parent.position + startPositionC - startPositionP;
        transform.rotation = parent.rotation;
    }
}
