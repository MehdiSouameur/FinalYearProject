using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    [SerializeField]
    private float reloadTime;

    [SerializeField]
    private Arrow arrowPrefab;

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private Transform target;

    [SerializeField]
    private float firePower;

    private Arrow currentArrow;

    private string enemyTag;

    private bool isReloading = false;

    private bool isFiring = false;


    void Awake()
    {
        ReloadFirstTime();
    }

    void Update()
    {
        Fire();
    }

    public void SetEnemyTag(string enemyTag)
    {
        this.enemyTag = enemyTag;
    }

    public void Reload()
    {
        if (isReloading || currentArrow != null) return;
        isReloading = true;
        StartCoroutine(ReloadAfterTime());
    }

    private IEnumerator ReloadAfterTime()
    {
        yield return new WaitForSeconds(reloadTime);
        GameObject arrow = GameObject.FindGameObjectWithTag("currentArrow");
        if (arrow != null)
        {
            Destroy(arrow);
        }
        currentArrow = Instantiate(arrowPrefab, spawnPoint);
        currentArrow.transform.localScale = Vector3.one;
        currentArrow.transform.localPosition = Vector3.zero;
        currentArrow.transform.rotation = spawnPoint.rotation;
        currentArrow.SetEnemyTag(enemyTag);
        isReloading = false;
        isFiring = false;
    }

    private void ReloadFirstTime()
    {
        GameObject arrow = GameObject.FindGameObjectWithTag("currentArrow");
        if (arrow != null)
        {
            Destroy(arrow);
        }
        currentArrow = Instantiate(arrowPrefab, spawnPoint);
        currentArrow.transform.localScale = Vector3.one;
        currentArrow.transform.localPosition = Vector3.zero;
        currentArrow.transform.rotation = spawnPoint.rotation;
        currentArrow.SetEnemyTag(enemyTag);
        isReloading = false;
        isFiring = false;
    }

    private IEnumerator waitBeforeShot()
    {
        yield return new WaitForSeconds(3);
        if (isReloading || currentArrow == null) yield break;

        Vector3 pos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(pos);
        Vector3 forward = rotation * Vector3.forward * firePower;
        var force = transform.TransformDirection(Vector3.forward * firePower);

        // Determine the rotation to the target
        Quaternion targetRotation = Quaternion.LookRotation(pos, Vector3.up);
        currentArrow.transform.rotation = targetRotation;

        currentArrow.Fly(forward);
        currentArrow = null;
        Reload();
    }

    public void Fire()
    {
        if (isFiring) return; // Exit the method if the coroutine is already running
        isFiring = true;
        StartCoroutine(waitBeforeShot());
    }

    public bool IsReady()
    {
        return (!isReloading && currentArrow != null);
    }

    public class DrawForwardVector : MonoBehaviour
    {
        public Color lineColor = Color.blue;
        public float lineLength = 1f;

        private void OnDrawGizmosSelected()
        {
            // Draw a line indicating the forward vector
            Debug.DrawLine(transform.position, transform.position + transform.forward * lineLength, lineColor);
        }
    }
}
