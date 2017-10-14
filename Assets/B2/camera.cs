using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {

    private GameObject player;
    private Vector3 initCameraPosition;
    private Quaternion initCameraRotation;
    private Vector3 initPlayerPosition;
    private Quaternion initPlayerRotation;

    // Use this for initialization
    void Start () {
        initCameraPosition = transform.position;
        initCameraRotation = transform.rotation;
        player = GameObject.FindGameObjectWithTag("Player");
        initPlayerPosition = player.transform.position;
        initPlayerRotation = player.transform.rotation;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position + player.transform.rotation * Quaternion.Inverse(initPlayerRotation) * (initCameraPosition - initPlayerPosition);
        transform.rotation = player.transform.rotation * Quaternion.Inverse(initPlayerRotation) * initCameraRotation;
    }
}
