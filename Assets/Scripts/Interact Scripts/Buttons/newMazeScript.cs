using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class newMazeScript : MonoBehaviour
{
    [SerializeField] GameObject mazeOne;
    [SerializeField] GameObject mazeTwo;
    [SerializeField] GameObject experimentFloor;
    private NavMeshSurface surface;

    public void secondLevel()
    {
        mazeOne.SetActive(false);
        mazeTwo.SetActive(true);
        surface = experimentFloor.GetComponent<NavMeshSurface>();
        surface.BuildNavMesh();
    }

    
}
