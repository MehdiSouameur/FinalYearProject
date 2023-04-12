using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class addTarget : MonoBehaviour
{

    //Target object to duplicate
    [SerializeField] GameObject target;
    [SerializeField] TMP_Text text;
    private Teleport teleportScript; //Teleport script component

    private Animator buttonAnim; //Animator component

    private void Awake()
    {
        buttonAnim = gameObject.GetComponent<Animator>();
    }

    //Function of the button
    public void buttonFunction()
    {

        Vector3 spawnPosition = new Vector3(0, 0, 0); //New position
        GameObject newTarget = Instantiate(target, spawnPosition, Quaternion.identity); //Spawn new target

        GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");
        teleportScript = newTarget.GetComponent<Teleport>();
        teleportScript.newPos();
        text.text = (targets.Length).ToString();
    }

    public void spawnTarget(Vector3 spawnPosition)
    {
        GameObject newTarget = Instantiate(target, spawnPosition, Quaternion.identity);
    }

    public void PlayAnimation()
    {
        buttonAnim.Play("ButtonPress", 0, 0.0f);
    }
}
