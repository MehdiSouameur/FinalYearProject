using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class robotSpeed : MonoBehaviour
{
    [SerializeField] float increment = 3.5f;
    [SerializeField] TMP_Text text;

    private Animator buttonAnim; //Animator component

    private void Awake()
    {
        buttonAnim = gameObject.GetComponent<Animator>();
    }


    public void addSpeed()
    {

        GameObject[] robots = GameObject.FindGameObjectsWithTag("Robot");

        foreach(GameObject robot in robots)
        {
            NavMeshAgent agent = robot.GetComponent<NavMeshAgent>();
            agent.speed = agent.speed + increment;
            text.text = (agent.speed).ToString();
        }

        

    }

    public void removeSpeed()
    {

        GameObject[] robots = GameObject.FindGameObjectsWithTag("Robot");

        foreach (GameObject robot in robots)
        {
            NavMeshAgent agent = robot.GetComponent<NavMeshAgent>();
            agent.speed = agent.speed - increment;
            text.text = (agent.speed).ToString();
        }

    }
}
