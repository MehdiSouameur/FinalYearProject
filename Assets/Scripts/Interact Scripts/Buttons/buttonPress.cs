using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonPress : MonoBehaviour
{
    private Animator buttonAnim; //Animator component

    private NavRobotMove robotStatus;//Script attached to Robot

    //Initialise 
    private void Awake()
    {
        buttonAnim = gameObject.GetComponent<Animator>();
        robotStatus = GameObject.FindGameObjectWithTag("Robot").GetComponent<NavRobotMove>();
    }

    //Function of the button
    public void buttonFunction()
    {
        PlayAnimation();//Play animation
        robotStatus.pausePlayExperiment(); //Pause/play experiment
    }

    public void PlayAnimation()
    {
        buttonAnim.Play("ButtonPress", 0, 0.0f);
    }
}
