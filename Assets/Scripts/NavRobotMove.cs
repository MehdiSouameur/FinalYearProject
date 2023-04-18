using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class NavRobotMove : MonoBehaviour
{

    [SerializeField] private Transform movePositionTransform;

    private NavMeshAgent navMeshAgent;

    public bool experimentStatus = true; //Experiment status

    GameObject TargetObject;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }


    // Update is called once per frame
    void Update()
    {
        //Only move if experiment is played
        if (experimentStatus)
        {
            moveRobot();
        }
        else
        {
            navMeshAgent.destination = gameObject.transform.position;
        }
    }

    public void moveRobot()
    {
        if (GameObject.FindWithTag("Target") != null)
        {
            selectTarget();
            navMeshAgent.enabled = true;
            navMeshAgent.destination = TargetObject.transform.position;
        }

        else if (GameObject.FindWithTag("Target") == null)
        {
            navMeshAgent.enabled = false;
        }
    }

    public void selectTarget()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");
        float closestDistance = float.MaxValue;

        foreach (GameObject target in targets)
        {
            float distance = Vector3.Distance(transform.position, target.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                TargetObject = target;
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Target")
        {
            Debug.Log("Robot collided with Target");
            Teleport targetTeleport = TargetObject.GetComponent<Teleport>();
            targetTeleport.newPos();
        }
    }

    //Pause or play experiment
    public void pausePlayExperiment()
    {
        if (experimentStatus)
        {
            experimentStatus = false;
            navMeshAgent.isStopped = true;
        }

        else
        {
            experimentStatus = true;
            navMeshAgent.isStopped = false;
        }
    }

}
