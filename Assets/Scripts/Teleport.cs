using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    [SerializeField] Transform root;
    [SerializeField] Transform zLimit;
    [SerializeField] Transform xLimit;
    [SerializeField] Transform yLimit;

    public float newX;
    public float newY;
    public float newZ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void newPos()
    {
        newX = Random.Range(root.position.x, xLimit.position.x);
        newY = Random.Range(root.position.y, yLimit.position.y);
        newZ = Random.Range(root.position.z, zLimit.position.z);

        gameObject.transform.position = new Vector3(newX, newY, newZ);
    }


}
