using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetLevel : MonoBehaviour
{
    public void reset()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");
        GameObject[] robots = GameObject.FindGameObjectsWithTag("Robot");

        if(targets != null)
        {
            foreach (GameObject target in targets)
            {
                Destroy(target);
            }
        }

        if(robots != null)
        {
            foreach (GameObject robot in robots)
            {
                Destroy(robot);
            }
        }
    }
}
