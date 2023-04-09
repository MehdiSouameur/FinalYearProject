using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class closeElevator : MonoBehaviour
{
    private Animator doorAnim; //Animator component
    [SerializeField] GameObject elevatorDoors;

    private void Awake()
    {
        doorAnim = elevatorDoors.GetComponent<Animator>();
    }

    public void buttonFunction()
    {
        doorAnim.Play("OpenClose", 0, 0.0f);
        StartCoroutine(WaitThenCallMethod(2f));
    }

    IEnumerator WaitThenCallMethod(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        // Call your method here
        SceneManager.LoadScene("ArcherSimulation");
    }
}
