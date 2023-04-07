using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] private int rayLength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excludeLayerName = null;

    private buttonPress raycastedObj;

    [SerializeField] private KeyCode pressButtonKey = KeyCode.Mouse0;

    private bool doOnce;

    private const string interactTag = "Interactable";

    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;

        //RayCast
        if(Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
        {
            //When we hit interactable object, do
            if (hit.collider.CompareTag(interactTag))
            {
                if (!doOnce)
                {
                    raycastedObj = hit.collider.gameObject.GetComponent<buttonPress>();

                }

                doOnce = true;

                if (Input.GetKeyDown(pressButtonKey))
                {
                    raycastedObj.buttonFunction();
                }
            }
        }
    }

}
