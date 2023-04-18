using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class targetCount : MonoBehaviour
{
    [SerializeField] TMP_Text text;
  
    // Update is called once per frame
    void Update()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");
        text.text = (targets.Length).ToString();
    }
}
