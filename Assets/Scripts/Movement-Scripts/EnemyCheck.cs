using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCheck : MonoBehaviour
{
    public bool enemyDetected = false;
    private Blink blink;
    private Collider myCollider; // Renamed variable to avoid conflicts with the Collider class
    private LayerMask enemyLayer;
     public float smoothFactor = 5f;

    void Start()
{
    myCollider = GetComponent<Collider>();

    // Find the parent object and get the Blink component
    blink = transform.parent.GetComponent<Blink>();

    if (blink == null)
    {
        Debug.LogError("Blink component not found on the parent object.");
    }

    // Assign the enemy layer to the layer mask
    enemyLayer = LayerMask.GetMask("Enemy");
}

    void Update()
{
    if (blink != null)
    {
        Vector3 dashDirection = (blink.GetMouseWorldPosition() - transform.position).normalized;
        Vector3 maxDashDistance = transform.position + dashDirection * blink.blinkDistance;

        // Limit the position within the desired radius
        Vector3 playerToCollider = myCollider.transform.position - blink.player.transform.position;
        float distanceToPlayer = playerToCollider.magnitude;

        float desiredRadius = 5f; // Set your desired radius here

        if (distanceToPlayer > desiredRadius)
        {
            myCollider.transform.position = blink.player.transform.position + playerToCollider.normalized * desiredRadius;
        }
        else
        {
            // Gradually move the collider towards the max dash distance
            myCollider.transform.position = Vector3.Lerp(myCollider.transform.position, maxDashDistance, Time.deltaTime * smoothFactor);
        }
    }
}

    private void OnTriggerEnter(Collider other)
    {
        
        if (((1 << other.gameObject.layer) & enemyLayer) != 0)
        {
            enemyDetected = true;
            blink.canBlink = false;
            Debug.Log("Ememy spotted");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (((1 << other.gameObject.layer) & enemyLayer) != 0)
        {
            enemyDetected = false;
            blink.canBlink = true;
        }
    }
}