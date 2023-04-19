using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dropPointScript : MonoBehaviour
{
    public int scoreCounter = 0;
    public TMP_Text text;


    void Update()
    {
        text.text = scoreCounter.ToString();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Target")
        {
            scoreCounter++;
            Destroy(other.gameObject);
        }
    }
}
