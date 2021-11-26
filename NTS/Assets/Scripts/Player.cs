using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Player : MonoBehaviour
{
    public bool testBool;
    public int testInt;
    public float testFloat;
    public string testString;
    private bool inputJump;
    public int myValue;
    private Rigidbody rb;
    private float horizontal;
    private bool isGrounded;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    private void Update()
    {
        /*if (myValue < 10)
        {
            Debug.Log("My Value is lower than 10");
        }
        else if (myValue > 10)
        {
            Debug.Log("My Value is higher than 10");
        }
        else if (myValue == 10)
        {
            Debug.Log("My Value is equal to 10");
        }*/

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("Space key was Pressed Down !!");
            rb.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
        }

        horizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontal * Time.deltaTime);
        transform.Translate((Vector3.forward * horizontal * Time.deltaTime));

        if (!inputJump)
        {
            inputJump = Input.GetKeyDown(KeyCode.Space);
        }

        horizontal = Input.GetAxis("Horizontal");
        
        if (!inputJump && isGrounded)
        {
            inputJump = Input.GetKeyDown(KeyCode.Space);
        }

        horizontal = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        if (inputJump)
        {
            rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
            inputJump = false;
        }

        if (horizontal != 0)
        {
            rb.AddForce(Vector3.right * horizontal * 10, ForceMode.Acceleration);
        }

        if (inputJump && isGrounded)
        {
            rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
            inputJump = false;
            isGrounded = false;
        }

        if (horizontal != 0)
        {
            rb.AddForce(Vector3.right * horizontal * 10, ForceMode.Acceleration);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        isGrounded = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        isGrounded = true;
    }
}
