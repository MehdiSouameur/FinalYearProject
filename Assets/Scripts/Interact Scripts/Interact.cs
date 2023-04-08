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

    //Script components on buttons
    private buttonPress playButton;
    private addTarget addTargetButton;
    private removeTarget removeTargetButton;

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

}
