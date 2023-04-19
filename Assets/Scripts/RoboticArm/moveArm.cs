using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveArm : MonoBehaviour
{
    public GameObject robotCase;
    public float speed = 35f;
    public float maxSpeed = 55f;
    public bool isMoving;
    Rigidbody rb;

    void Start()
    {
        rb = robotCase.GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed); // Cap the speed 

        //If Not moving, sotp arm
        if (!isMoving)
        {
            stop();
        }
    }

    //Move Arm forward along x axis
    public void forward()
    {
        Vector3 force = new Vector3(speed, 0f, 0f);
        rb.AddForce(force, ForceMode.Force);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, 10f);
    }

    //Move Arm backward along x axis
    public void backwards()
    {
        Vector3 force = new Vector3(-speed, 0f, 0f);
        rb.AddForce(force, ForceMode.Force);
    }

    //Move Arm forward along z axis
    public void left()
    {
        Vector3 force = new Vector3(0f, 0f, speed);
        rb.AddForce(force, ForceMode.Force);
    }

    //Move Arm backward along z axis
    public void right()
    {
        Vector3 force = new Vector3(0f, 0f, -speed);
        rb.AddForce(force, ForceMode.Force);
    }

    //Stop arm
    public void stop()
    {
        rb.velocity = Vector3.zero;
    }
}
