using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenCount : MonoBehaviour
{
    public int screenIndex;

    private void Awake()
    {
        screenIndex = 0;
    }

    public void addCount()
    {
        screenIndex++;
    }

    public void removeCount()
    {
        screenIndex--;
    }
}
