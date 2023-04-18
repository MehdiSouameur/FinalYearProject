using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Teleport : MonoBehaviour
{

    [SerializeField] Transform root;
    [SerializeField] Transform zLimit;
    [SerializeField] Transform xLimit;
    [SerializeField] Transform yLimit;

    [SerializeField] GameObject targetPrefab;
        
    private float newX;
    private float newY;
    private float newZ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void SpawnTarget()
    {
        // Sample a random position on the navmesh
        NavMeshHit hit;
        NavMesh.SamplePosition(transform.position, out hit, 10f, NavMesh.AllAreas);

        // Instantiate the target prefab at the sampled position
        GameObject target = Instantiate(targetPrefab, hit.position, Quaternion.identity);
    }

    public void newPos()
    {
        newX = Random.Range(root.position.x, xLimit.position.x);
        newY = Random.Range(root.position.y, yLimit.position.y);
        newZ = Random.Range(root.position.z, zLimit.position.z);

        Debug.Log("Position Changed");
        gameObject.transform.position = new Vector3(newX, newY, newZ);
    }

    public Vector3 returnNewPos()
    {
        newX = Random.Range(root.position.x, xLimit.position.x);
        newY = Random.Range(root.position.y, yLimit.position.y);
        newZ = Random.Range(root.position.z, zLimit.position.z);

        Vector3 newPosition = new Vector3(newX, newY, newZ);
        return newPosition;
    }

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Wall")
        {
            newPos();
        }
    }


}
