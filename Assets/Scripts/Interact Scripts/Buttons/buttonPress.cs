using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class buttonPress : MonoBehaviour
{
    private Animator buttonAnim; //Animator component

    private NavRobotMove robotStatus;//Script attached to Robot
    [SerializeField] TMP_Text text;
    bool status = true;

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
        status = !status;
        if (status)
            text.text = "Active";
        else
            text.text = "Inactive";
    }

    public void PlayAnimation()
    {
        buttonAnim.Play("playAnim", 0, 0.0f);
    }
}
