using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCheck : MonoBehaviour
{
    public bool enemyDetected = false;
    private MovementManager movementManager;
    private PlayerBlink blink;
    private Collider myCollider;
    private LayerMask enemyLayer;
    public float smoothFactor = 5f;

    private Renderer rend; // Reference to the object's renderer component

    public Color colorWhenCannotBlink = new Color(1f, 0f, 0f, 1f); // Red color when canBlink is false
    public float alphaWhenCannotBlink = 0.5f; // Set your desired alpha value when canBlink is false

    void Start()
    {
        myCollider = GetComponent<Collider>();
        rend = GetComponent<Renderer>(); // Get the renderer component attached to the object

        // Find the parent object and get components
        movementManager = transform.parent.GetComponent<MovementManager>();
        blink = transform.parent.GetComponent<PlayerBlink>();
        // Assign the enemy layer to the layer mask
        enemyLayer = LayerMask.GetMask("Enemy");
    }

    void Update()
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

        // Check if canBlink is false and change the color and alpha accordingly
        if (!movementManager.canBlink)
        {
            // Change the color and alpha of the object
            rend.material.color = new Color(colorWhenCannotBlink.r, colorWhenCannotBlink.g, colorWhenCannotBlink.b, alphaWhenCannotBlink);
        }
        else
        {
            // Reset the color and alpha to its original state or another default color
            rend.material.color = Color.green; // Change to the desired default color
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & enemyLayer) != 0)
        {
            enemyDetected = true;
            movementManager.canBlink = false;
            Debug.Log("Enemy spotted");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (((1 << other.gameObject.layer) & enemyLayer) != 0)
        {
            enemyDetected = false;
            movementManager.canBlink = true;
        }
    }
}

