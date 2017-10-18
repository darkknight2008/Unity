﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{

    public float rotationSpeed;
    public float scaleSpeed;
    public float backSpeed;
    public float pv;

    private GameObject player;
    private Vector3 initCameraPosition;
    private Quaternion initCameraRotation;
    private Vector3 initPlayerPosition;
    private Quaternion initPlayerRotation;
    private Quaternion R0t;
    private Quaternion Rscript;
    private float cameraDistanceScale;
    private Vector3 camerPositionLocal;
    private Quaternion Q;

    // Use this for initialization
    void Start()
    {
        initCameraPosition = transform.position;
        initCameraRotation = transform.rotation;
        player = GameObject.FindGameObjectWithTag("Player");
        initPlayerPosition = player.transform.position;
        initPlayerRotation = player.transform.rotation;
        Rscript = Quaternion.identity;
        cameraDistanceScale = 1.0f;
        camerPositionLocal = initCameraPosition - initPlayerPosition;
    }

    // Update is called once per frame
    void Update()
    {
        cameraDistanceScale += - Input.GetAxis("Mouse ScrollWheel")* Time.deltaTime * scaleSpeed;

        if (Input.GetKey("f") && Input.GetButton("Fire1"))
        {
            camerPositionLocal = Quaternion.AngleAxis(rotationSpeed * Time.deltaTime * Input.GetAxis("Mouse X"), Vector3.up) * camerPositionLocal;
            if ((Input.GetAxis("Mouse Y") < 0 && camerPositionLocal.y <= 0.95 * camerPositionLocal.magnitude) || (Input.GetAxis("Mouse Y") > 0 && camerPositionLocal.y >= -0.5 * camerPositionLocal.magnitude))
            {
                camerPositionLocal = Quaternion.AngleAxis(rotationSpeed * Time.deltaTime * Input.GetAxis("Mouse Y"), Vector3.Cross(Vector3.up, camerPositionLocal)) * camerPositionLocal;
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            camerPositionLocal = Quaternion.AngleAxis(-rotationSpeed * Time.deltaTime, Vector3.up) * camerPositionLocal;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            camerPositionLocal = Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, Vector3.up) * camerPositionLocal;
        }
        if (Input.GetKey(KeyCode.UpArrow) && camerPositionLocal.y <= 0.95 * camerPositionLocal.magnitude)
        {
            camerPositionLocal = Quaternion.AngleAxis(-rotationSpeed * Time.deltaTime, Vector3.Cross(Vector3.up, camerPositionLocal)) * camerPositionLocal;
        }
        if (Input.GetKey(KeyCode.DownArrow) && camerPositionLocal.y >= -0.5 * camerPositionLocal.magnitude)
        {
            camerPositionLocal = Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, Vector3.Cross(Vector3.up, camerPositionLocal)) * camerPositionLocal;
        }
        if (Input.GetKey("r"))
        {
            camerPositionLocal = initCameraPosition - initPlayerPosition;
            cameraDistanceScale = 1.0f;
        }

        Q.SetFromToRotation(camerPositionLocal, initCameraPosition - initPlayerPosition);
        pv = player.GetComponent<Rigidbody>().velocity.magnitude;
        camerPositionLocal = Quaternion.Lerp(Quaternion.identity, Q, Time.deltaTime * pv * backSpeed) * camerPositionLocal;
        R0t = player.transform.rotation * Quaternion.Inverse(initPlayerRotation);
        transform.position = player.transform.position + R0t * camerPositionLocal * cameraDistanceScale;
        Q.SetLookRotation(player.transform.position - transform.position);
        transform.rotation = Q;
        //transform.rotation = R0t * Rscript * initCameraRotation;
    }
}
