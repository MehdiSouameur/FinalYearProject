using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnTarget : MonoBehaviour
{
    public Transform root;
    public Transform zLimit;
    public Transform xLimit;
    public Transform yLimit;

    private float newX;
    private float newY;
    private float newZ;

    public GameObject targetPrefab;

    public void spawnNewTarget()
    {
        Vector3 newPos = returnNewPos();
        GameObject newTarget = Instantiate(targetPrefab, newPos, Quaternion.identity);
        newTarget.tag = "Target";
    }

    public Vector3 returnNewPos()
    {
        newX = Random.Range(root.position.x, xLimit.position.x);
        newY = Random.Range(root.position.y, yLimit.position.y);
        newZ = Random.Range(root.position.z, zLimit.position.z);

        Vector3 newPosition = new Vector3(newX, newY, newZ);
        return newPosition;
    }
}
