using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMovement : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] float movementSpeed = 10f;
    [SerializeField] float rotationalDamp = 0.5f;

    public bool facingTarget = false;

    private void Start()
    {
        
    }

    void Move()
    {
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }


    // Update is called once per frame
    void Update()
    {
        if(facingTarget == true)
        {
            Move();
        }
        Turn();
    }

    void Turn()
    {
        //Vector to target
        Vector3 pos = target.position - transform.position;
        //Forward vector of drone
        Vector3 forward = transform.forward;
        //Angle between target vector and forward vector
        float angle = Vector3.Angle(pos, forward);
        Debug.Log("Angle: " + angle);

        //Rotate towards the drone vector
        Quaternion rotation = Quaternion.LookRotation(pos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);

        //If angle is small enough, start going forward
        if(0f <= angle && angle < 3f)
        {
            Debug.Log("Angle Achieved: " + angle);
            transform.rotation = rotation;
            facingTarget = true;

        } else
        {
            facingTarget = false;
        }
        
        

    }


}
