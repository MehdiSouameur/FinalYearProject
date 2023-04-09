using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotCountScript : MonoBehaviour
{
    //Target robot to duplicate
    [SerializeField] GameObject target;
    private Teleport teleportScript; //Teleport script component

    private Animator buttonAnim; //Animator component

    private void Awake()
    {
        buttonAnim = gameObject.GetComponent<Animator>();
    }

    public void addRobot()
    {
        buttonAnim.Play("ButtonPress", 0, 0.0f); //Play animation

        Vector3 spawnPosition = new Vector3(0, 0, 0); //New position
        GameObject newRobot = Instantiate(target, spawnPosition, Quaternion.identity); //Spawn new target

        teleportScript = newRobot.GetComponent<Teleport>();
        teleportScript.newPos();
    }
}
