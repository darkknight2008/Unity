using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_wall : MonoBehaviour {

    public float delta;

    private Transform wall;

    // Use this for initialization
    void Start () {
        wall = GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        wall.position = wall.position - delta * movement;
    }
}
