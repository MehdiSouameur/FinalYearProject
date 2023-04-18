using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vectorForward : MonoBehaviour
{
    // The speed at which the object moves forward
    public float speed = 10f;

    // The rigidbody component attached to the object
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        // Get the rigidbody component
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed, ForceMode.Acceleration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
