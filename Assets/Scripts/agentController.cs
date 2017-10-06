using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class agentController : MonoBehaviour {

    private Vector3 p;

    public agentSelecter selecter;

    private agentExample targetscript;
    private monster2 monster_targetscript;

    //private Rigidbody crate;

    public GameObject crate1;
    public GameObject crate2;
    public GameObject crate3;

    private bool move1;
    private bool move2;
    private bool move3;

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
                clear_move();
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
                    clear_move();
                }
                else if (hit.collider.CompareTag("Monster"))
                {
                    monster_targetscript = hit.collider.GetComponent<monster2>();
                    monster_targetscript.SwitchStatus();
                    clear_move();
                }
                else
                {
                    selecter.DeselectAll();
                }

                if (hit.collider.CompareTag("mobile1"))
                {
                    move1 = true;
                    //print(move2);
                    move2 = false;
                    move3 = false;
                   
                }

                if (hit.collider.CompareTag("mobile2"))
                {
                    move2 = true;
                    move1 = false;
                    move3 = false;

                }

                if (hit.collider.CompareTag("mobile3"))
                {
                    move3 = true;
                    move1 = false;
                    move2 = false;

                }
            }
        }
        if (move1 == true)
        {
            if (Input.GetKey(KeyCode.U))
            {
                crate1.transform.Translate(new Vector3(0, 0, 5f * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.J))
            {
                crate1.transform.Translate(new Vector3(0, 0, -1 * 5f * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.H))
            {
                crate1.transform.Translate(new Vector3(-1 * 5f * Time.deltaTime, 0, 0));
            }
            if (Input.GetKey(KeyCode.K))
            {
                crate1.transform.Translate(new Vector3(5f * Time.deltaTime, 0, 0));
            }
        }

        if (move2 == true)
        {
            if (Input.GetKey(KeyCode.U))
            {
                crate2.transform.Translate(new Vector3(0, 0, 5f * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.J))
            {
                crate2.transform.Translate(new Vector3(0, 0, -1 * 5f * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.H))
            {
                crate2.transform.Translate(new Vector3(-1 * 5f * Time.deltaTime, 0, 0));
            }
            if (Input.GetKey(KeyCode.K))
            {
                crate2.transform.Translate(new Vector3(5f * Time.deltaTime, 0, 0));
            }
        }
        if (move3 == true)
        {
            if (Input.GetKey(KeyCode.U))
            {
                crate3.transform.Translate(new Vector3(0, 0, 5f * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.J))
            {
                crate3.transform.Translate(new Vector3(0, 0, -1 * 5f * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.H))
            {
                crate3.transform.Translate(new Vector3(-1 * 5f * Time.deltaTime, 0, 0));
            }
            if (Input.GetKey(KeyCode.K))
            {
                crate3.transform.Translate(new Vector3(5f * Time.deltaTime, 0, 0));
            }
        }
    }
    void clear_move()
    {
        move1 = false;
        move2 = false;
        move3 = false;

    }
}
