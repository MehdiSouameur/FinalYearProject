using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    private float damage;

    [SerializeField]
    private float torque;

    [SerializeField]
    private Rigidbody rigidbody;

    private string archerTag;

    private bool didHit;

    public void SetEnemyTag(string enemyTag)
    {
        this.archerTag = enemyTag;
    }

    public void Fly(Vector3 force)
    {
        rigidbody.isKinematic = false;
        rigidbody.AddForce(force, ForceMode.Impulse);
    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Collision Detected");
        if (didHit) return;
        didHit = true;

        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        rigidbody.isKinematic = true;
       
    }
}
