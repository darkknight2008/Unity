using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movable : MonoBehaviour {

   // private Rigidbody crate2;
    //private bool move;
    // Use this for initialization
    void Start () {
       // crate2 = GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void FixedUpdate(){
       /* if (move == true)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            //roll the ball on the table
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            crate2.AddForce(movement * 2f);

        }
        else
        {
            crate2.AddForce(0f,0f,0f);
        }*/
}
 /*public  void set_move()
    {
        move = true;
    }
  public  void stop_move()
    {
        move = false;
    }*/
}
