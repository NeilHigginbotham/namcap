using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    public float speed = 10f;
    //private float maxSpeed = 600f;


    void Start()
    { 
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Move the ghost upon key presses
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            rigidbody2d.velocity = new Vector2(0f, speed);
            //rigidbody2d.AddForce(transform.up * speed); Old method of movement. Current code sets a steady velocity.
        }
        if (Input.GetKeyDown("a"))
        {
            rigidbody2d.velocity = new Vector2(-speed, 0f);
        }
        if (Input.GetKeyDown("s"))
        {
            rigidbody2d.velocity = new Vector2(0f, -speed);
        }
        if (Input.GetKeyDown("d"))
        {
            rigidbody2d.velocity = new Vector2(speed, 0f);
        }
    }


    /*    Supposed to set a limit to the speed of the ghost but isn't working properly with our movement method.
    private void FixedUpdate()
    {
            if (GetComponent<Rigidbody2D>().velocity.magnitude > maxSpeed)
            {
                GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity.normalized * maxSpeed;
            }
    } */
      
    }
