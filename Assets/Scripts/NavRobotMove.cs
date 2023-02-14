using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class NavRobotMove : MonoBehaviour
{

    [SerializeField] private Transform movePositionTransform;

    GameObject TargetObject;

    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        TargetObject = GameObject.Find("Target");
    }


    // Update is called once per frame
    void Update()
    {
      navMeshAgent.destination = movePositionTransform.position;
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
