using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] private int rayLength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excludeLayerName = null;
    [SerializeField] private KeyCode pressButtonKey = KeyCode.Mouse0;

    private bool doOnce;

    //Tags for different buttons
    private const string PausePlayTag = "PausePlayButton";
    private const string AddTargetTag = "AddTargetButton";
    private const string RemoveTargetTag = "RemoveTargetButton";
    private const string NextFeedTag = "NextFeedButton";
    private const string elevatorTag = "ElevatorButton";
    private const string PreviousFeedTag = "PreviousFeedButton";
    private const string speedTag = "SpeedButton";
    private const string slowTag = "SlowButton";
    private const string addRobotTag = "AddRobotButton";

    //Script components on buttons
    private buttonPress playButton;
    private addTarget addTargetButton;
    private removeTarget removeTargetButton;
    private nextFeed nextFeedButton;
    private closeElevator elevatorScript;
    private robotSpeed speedScript;
    private robotCountScript updateRobotScript;

    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;

        //RayCast
        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
        {
            //When we hit interactable object, do
            if (hit.collider.CompareTag(PausePlayTag))
            {
                pausePlay(hit);
            }

            if (hit.collider.CompareTag(AddTargetTag))
            {
                plusTarget(hit);
            }

            if (hit.collider.CompareTag(RemoveTargetTag))
            {
                minusTarget(hit);
            }

            if (hit.collider.CompareTag(NextFeedTag))
            {
                NextFeed(hit);
            }

            if (hit.collider.CompareTag(PreviousFeedTag))
            {
                PreviousFeed(hit);
            }

            if (hit.collider.CompareTag(elevatorTag))
            {
                closeElevatorFunction(hit);
            }

            if (hit.collider.CompareTag(speedTag))
            {
                addRobotSpeed(hit);
            }

            if (hit.collider.CompareTag(slowTag))
            {
                removeRobotSpeed(hit);
            }

            if (hit.collider.CompareTag(addRobotTag))
            {
                addOneRobot(hit);
            }

        }
    }

    //Pause or play experiment button
    private void pausePlay(RaycastHit hit)
    {
       
        playButton = hit.collider.gameObject.GetComponent<buttonPress>();


        if (Input.GetKeyDown(pressButtonKey))
        {
            playButton.buttonFunction();
        }
    }

    //Add Target button
    private void plusTarget(RaycastHit hit)
    {
        
        addTargetButton = hit.collider.gameObject.GetComponent<addTarget>();

     
        if (Input.GetKeyDown(pressButtonKey))
        {
            addTargetButton.buttonFunction();
        }
    }

    //Remove Target button
    private void minusTarget(RaycastHit hit)
    {
        
        removeTargetButton = hit.collider.gameObject.GetComponent<removeTarget>();

        if (Input.GetKeyDown(pressButtonKey))
        {
            removeTargetButton.buttonFunction();
        }
    }

    //Next Feed Button
    private void NextFeed(RaycastHit hit)
    {
        Debug.Log("Feed pressed");
        nextFeedButton = hit.collider.gameObject.GetComponent<nextFeed>();

        if (Input.GetKeyDown(pressButtonKey))
        {
            nextFeedButton.followingFeed();
        }
    }

    //Previous Feed Button
    private void PreviousFeed(RaycastHit hit)
    {
        Debug.Log("Feed pressed");
        nextFeedButton = hit.collider.gameObject.GetComponent<nextFeed>();

        if (Input.GetKeyDown(pressButtonKey))
        {
            nextFeedButton.previousFeed();
        }
    }

    //Elevator Button
    private void closeElevatorFunction(RaycastHit hit)
    {

        elevatorScript = hit.collider.gameObject.GetComponent<closeElevator>();

        if (Input.GetKeyDown(pressButtonKey))
        {
            elevatorScript.buttonFunction();
        }
    }

    //Add robot speed button
    private void addRobotSpeed(RaycastHit hit)
    {

        speedScript = hit.collider.gameObject.GetComponent<robotSpeed>();

        if (Input.GetKeyDown(pressButtonKey))
        {
            speedScript.addSpeed();
        }
    }

    private void removeRobotSpeed(RaycastHit hit)
    {

        speedScript = hit.collider.gameObject.GetComponent<robotSpeed>();

        if (Input.GetKeyDown(pressButtonKey))
        {
            speedScript.removeSpeed();
        }
    }

    private void addOneRobot(RaycastHit hit)
    {

        updateRobotScript = hit.collider.gameObject.GetComponent<robotCountScript>();

        if (Input.GetKeyDown(pressButtonKey))
        {
            updateRobotScript.addRobot();
        }
    }

}
