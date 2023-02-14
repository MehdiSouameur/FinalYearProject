using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class droneCollision : MonoBehaviour
{
    GameObject TargetObject;
    // Start is called before the first frame update
    void Start()
    {
        TargetObject = GameObject.Find("Target");
    }

    private void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.tag == "Target")
        {
            
            Teleport targetTeleport = TargetObject.GetComponent<Teleport>();
            targetTeleport.newPos();
        }
    }
}
