using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class robotSpeed : MonoBehaviour
{
    [SerializeField] float increment = 3.5f;

    private Animator buttonAnim; //Animator component

    private void Awake()
    {
        buttonAnim = gameObject.GetComponent<Animator>();
    }


    public void addSpeed()
    {
        buttonAnim.Play("ButtonPress", 0, 0.0f);

        GameObject[] robots = GameObject.FindGameObjectsWithTag("Robot");

        foreach(GameObject robot in robots)
        {
            NavMeshAgent agent = robot.GetComponent<NavMeshAgent>();
            agent.speed = agent.speed + increment;
        }

    }

    public void removeSpeed()
    {
        buttonAnim.Play("ButtonPress", 0, 0.0f);

        GameObject[] robots = GameObject.FindGameObjectsWithTag("Robot");

        foreach (GameObject robot in robots)
        {
            NavMeshAgent agent = robot.GetComponent<NavMeshAgent>();
            agent.speed = agent.speed - increment;
        }

    }
}
