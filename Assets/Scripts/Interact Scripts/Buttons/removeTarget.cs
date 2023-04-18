using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeTarget : MonoBehaviour
{
    private Animator buttonAnim; //Animator component
    private const string TargetTag = "Target";

    private void Awake()
    {
        buttonAnim = gameObject.GetComponent<Animator>();
    }

    public void buttonFunction()
    {

        GameObject[] targets = GameObject.FindGameObjectsWithTag(TargetTag);

        destroyTarget(targets);

    }

    private void destroyTarget(GameObject[] targets)
    {
        if (targets.Length > 0)
        {
            // Generate a random index in the range of the array length
            int randomIndex = Random.Range(0, targets.Length);

            // Get the random GameObject from the array
            GameObject randomObject = targets[randomIndex];

            // Destroy the random GameObject
            Destroy(randomObject);
        }
    }

    public void PlayAnimation()
    {
        buttonAnim.Play("ButtonPress", 0, 0.0f);
    }
}
