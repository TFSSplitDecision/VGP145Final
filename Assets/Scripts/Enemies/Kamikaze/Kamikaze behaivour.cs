using UnityEngine;

public class Kamikaze : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float walkSpeed = 2f; // Initial walking speed
    public float runSpeed = 5f; // Running speed when close to the player
    public float detectionDistance = 5f; // Distance at which the enemy starts running
    public float selfDestructDelay = 1.5f; // Time delay before self-destructing

    private float currentSpeed;
    private bool isRunning = false;

    void Start()
    {
        currentSpeed = walkSpeed;
    }

    void Update()
    {
        // Check if the player is not null (exists)
        if (player != null)
        {
            // Calculate distance to the player
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            // Walk towards the player
            transform.position = Vector3.MoveTowards(transform.position, player.position, currentSpeed * Time.deltaTime);

            // Rotate to face the player
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            //Once within the a certain distance from the player, initiate launching visual

            //On launch time, grab player location and fly to that

            //On Land, explode
            //damage on radius and, impulse explosion
        }
    }

    void SelfDestruct()
    {
        // Implement self-destruct behavior here (e.g., particle effects, damage to player, etc.)
        Destroy(gameObject);
    }
}
