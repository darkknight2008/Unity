using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{

    Animator anim;
    Rigidbody rb;

    public float speed;
    public float backspeed;
    public float angleSpeed;
    public float jumpHeight;
    public float extraPower;

    private float velocity;
    private float angleVelocity;
    private float distToGround;
    private bool isOnGround;
    private Vector3 deltaP;

    // Use this for initialization
    void Start()
    {
        anim = transform.GetChild(0).gameObject.GetComponent<Animator>();
        //anim = GameObject.FindGameObjectWithTag("Monster").GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        distToGround = transform.localScale.y;
        isOnGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        float rotate = Input.GetAxis("Horizontal");
        float move = Input.GetAxis("Vertical");

        Vector3 direction = transform.rotation * new Vector3(0.0f, 0.0f, 1.0f);

        // Move by Force
        //if (move >= 0)
        //{
        //    rb.AddRelativeForce(new Vector3(0.0f, 0.0f, speed * move));
        //    rb.AddRelativeTorque(new Vector3(0.0f, -angleSpeed * rotate, 0.0f));        
        //}
        //else
        //{
        //    rb.AddRelativeForce(new Vector3(0.0f, 0.0f, backspeed * move));
        //    rb.AddRelativeTorque(new Vector3(0.0f, angleSpeed * rotate, 0.0f));
        //}
        //anim.SetFloat("v", Vector3.Dot(rb.velocity, direction));

        // Move by Position
        velocity = (move >= 0) ? speed: backspeed;
        velocity *= move;
        velocity = (Input.GetKey(KeyCode.Z)) ? velocity * extraPower : velocity;
        rb.transform.position += velocity * Time.deltaTime * direction;
        angleVelocity = (move >= 0) ? -angleSpeed : angleSpeed;
        angleVelocity *= rotate;
        rb.transform.rotation = Quaternion.Euler(new Vector3(0.0f, angleVelocity * Time.deltaTime, 0.0f)) * rb.transform.rotation;
        anim.SetFloat("v", velocity);
        anim.SetFloat("angle", angleVelocity);

        //deltaP = move * Time.deltaTime * direction;
        //if (Input.GetKeyDown(KeyCode.LeftAlt))
        //{
        //    deltaP *= extraPower;
        //}
        //if (move >= 0)
        //{
        //    rb.transform.position += deltaP * speed;
        //    rb.transform.rotation = Quaternion.Euler(new Vector3(0.0f, -angleSpeed * rotate * Time.deltaTime, 0.0f)) * rb.transform.rotation;
        //    anim.SetFloat("v", speed * move);
        //}
        //else
        //{
        //    rb.transform.position += deltaP * backspeed;
        //    rb.transform.rotation = Quaternion.Euler(new Vector3(0.0f, angleSpeed * rotate * Time.deltaTime, 0.0f)) * rb.transform.rotation;
        //    anim.SetFloat("v", backspeed * move);
        //}

        //if (Input.GetKey("space") && isOnGround)
        if (Input.GetKey("v") && isOnGround)
        {
            rb.AddForce(new Vector3(0.0f, jumpHeight, 0.0f), ForceMode.Impulse);
            isOnGround = false;
            anim.SetBool("jump",true);
        }
        //if (rotate != 0.0f) {
        //    anim.SetBool("jump",false);
        //}
        

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isOnGround = true;
            anim.SetBool("jump", false);
        }
    }

}
