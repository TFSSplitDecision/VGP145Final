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
    public LayerMask groundLayer;
    public float smoothFactor = 5f;

    private Renderer rend; // Reference to the object's renderer component

    public Color colorWhenCannotBlink = new Color(1f, 0f, 0f, 1f); // Red color when canBlink is false
    public float alphaWhenCannotBlink = 0.5f; // Set your desired alpha value when canBlink is false

    public float radius = 5f; // Set desired radius here

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
        Vector3 groundPos = GetMouseWorldPosition();
        Vector3 dashDirection = (GetMouseWorldPosition() - transform.position).normalized;
        Vector3 maxBlinkDistance = transform.position + dashDirection * blink.blinkDistance;

        // Gradually move the collider towards the max dash distance
        // myCollider.transform.position = Vector3.Lerp(transform.position, maxBlinkDistance, Time.deltaTime * smoothFactor);
        myCollider.transform.position = groundPos;

        // Limit the position within the desired radius
        Vector3 colliderPos = transform.position;
        Vector3 playerPos = blink.player.transform.position;
        playerPos.y = colliderPos.y;

        Vector3 playerToCollider = colliderPos - playerPos;
        float distanceToPlayer = playerToCollider.magnitude;

        if (distanceToPlayer > radius)
        {
            // If the distance exceeds the maximum, reposition within the radius
            transform.position = playerPos + playerToCollider.normalized * radius;
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

    private Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100f, groundLayer))
        {
            Debug.Log(hit.collider.gameObject);
            return hit.point;
        }
        return Vector3.zero;
    }
}