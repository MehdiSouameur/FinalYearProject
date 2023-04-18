using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotCountScript : MonoBehaviour
{
    //Target robot to duplicate
    [SerializeField] GameObject target;
    private Teleport teleportScript; //Teleport script component

    //private Animator buttonAnim; //Animator component

    private void Awake()
    {
        //buttonAnim = gameObject.GetComponent<Animator>();
    }

    public void addRobot()
    {
        //buttonAnim.Play("ButtonPress", 0, 0.0f); //Play animation
        teleportScript = gameObject.GetComponent<Teleport>();
        Vector3 spawnPosition = teleportScript.returnNewPos(); //New position
        GameObject newRobot = Instantiate(target, spawnPosition, Quaternion.identity); //Spawn new target

        newRobot.tag = "Robot";
        NavRobotMove navMoveScript = newRobot.GetComponent<NavRobotMove>(); //Get NavRobotMove script component
        navMoveScript.enabled = true; //Activate NavRobotMove script component

    }

    public void removeRobot()
    {
        GameObject[] robots = GameObject.FindGameObjectsWithTag("Robot");

        if (robots.Length > 0)
        {
            // Generate a random index in the range of the array length
            int randomIndex = Random.Range(0, robots.Length);

            // Get the random GameObject from the array
            GameObject randomObject = robots[randomIndex];

            // Destroy the random GameObject
            Destroy(randomObject);
        }
    }
}
