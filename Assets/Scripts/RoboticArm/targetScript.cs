using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetScript : MonoBehaviour
{
    [SerializeField] Transform spawn;
    [SerializeField] GameObject parent;

    public GameObject hand;

    robothandController handScript;

    public bool grabbed = false;

    Rigidbody rb;

    void Awake()
    {
        handScript = hand.GetComponent<robothandController>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!handScript.gripped && (transform.parent == parent.transform))
        {
            Debug.Log("Object released!");
            transform.SetParent(null);
            rb.useGravity = true;
        }
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "robotFinger" && handScript.gripped)
        {

            Debug.Log("Object Gripped");
            rb.useGravity = false;
            transform.SetParent(parent.transform);
            transform.position = spawn.position;
            grabbed = true;
                
            
        }
    }


}
