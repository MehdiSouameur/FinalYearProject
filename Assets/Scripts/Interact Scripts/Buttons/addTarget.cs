using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class addTarget : MonoBehaviour
{
    [SerializeField] GameObject levelCenter;
    [SerializeField] GameObject targetPrefab;

    public float range = 10.0f;

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }

    void OnDrawGizmos()
    {
        Vector3 point;
        if (RandomPoint(transform.position, range, out point))
        {
            Gizmos.DrawSphere(point, 0.1f);
        }
    }

    public void buttonFunction()
    {
        Vector3 point;
        RandomPoint(levelCenter.transform.position, range, out point);
        GameObject newTarget = Instantiate(targetPrefab, point, Quaternion.identity);
        BoxCollider boxCollider = newTarget.GetComponent<BoxCollider>();
        boxCollider.isTrigger = false;
        newTarget.tag = "Target";
    }

}
