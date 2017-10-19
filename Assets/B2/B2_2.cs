using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B2_2 : MonoBehaviour {

    private float y_distance = 0f;
    private Vector3 initCameraPosition;
    private Quaternion initCameraRotation;
    private Vector3 p;



    // Use this for initialization
    void Start()
    {
        initCameraPosition = transform.position;
        initCameraRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        //scaling
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            y_distance = Input.GetAxis("Mouse ScrollWheel") * 10f;
            if (transform.position.y > 5 && y_distance >0)
            {
                transform.position = transform.position + transform.forward * y_distance;
            }
            if (transform.position.y < 1.5 && y_distance < 0)
            {
                transform.position = transform.position + transform.forward * y_distance;
            }
            if (transform.position.y <= 5 && transform.position.y >= 1.5)
            {
                transform.position = transform.position + transform.forward * y_distance;
            }
        }
        //movePosition
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, 5f * Time.deltaTime, 5f * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, -1 * 5f * Time.deltaTime, -1 * 5f * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-1 * 5f * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(5f * Time.deltaTime, 0, 0));
        }

        //rotation
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, 10f * Time.deltaTime, -10f * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, -10f * Time.deltaTime, 10f * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(new Vector3(-10f * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(new Vector3(10f * Time.deltaTime, 0, 0));
        }
    }
}
