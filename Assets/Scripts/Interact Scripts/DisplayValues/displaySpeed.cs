using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class displaySpeed : MonoBehaviour
{
    [SerializeField] TMP_Text text;

    void Update()
    {
        GameObject[] robots = GameObject.FindGameObjectsWithTag("Robot");
        if(robots.Length > 0)
        {
            NavMeshAgent agent = robots[0].GetComponent<NavMeshAgent>();
            text.text = (agent.speed).ToString();
        }
        else
        {
            text.text = "";
        }
    }
}
