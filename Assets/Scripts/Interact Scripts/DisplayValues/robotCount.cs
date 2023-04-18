using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class robotCount : MonoBehaviour
{

    [SerializeField] TMP_Text text;

    // Update is called once per frame
    void Update()
    {
        GameObject[] robots = GameObject.FindGameObjectsWithTag("Robot");
        text.text = (robots.Length).ToString();
    }
}
