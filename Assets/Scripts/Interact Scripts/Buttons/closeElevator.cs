using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class closeElevator : MonoBehaviour
{
    private Animator doorAnim; //Animator component
    [SerializeField] GameObject elevatorDoors;

    bool open = false;

    private void Awake()
    {
        doorAnim = elevatorDoors.GetComponent<Animator>();
    }

    public void buttonFunction()
    {
        if (open)
        {
            doorAnim.Play("Close", 0, 0.0f);
            StartCoroutine(WaitThenCallMethod(2f));
            open = !open;
        }
        else
        {
            doorAnim.Play("Open", 0, 0.0f);
            open = !open;
        }
    }

    IEnumerator WaitThenCallMethod(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        // Call your method here
        SceneManager.LoadScene("ArcherSimulation");
    }
}
