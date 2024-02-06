<<<<<<< Updated upstream
using UnityEngine;
=======
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
>>>>>>> Stashed changes

public class suicideBomberAI : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float walkSpeed = 2f; // Initial walking speed
<<<<<<< Updated upstream
    public float runSpeed = 5f; // Running speed when close to the player
=======
    public float runSpeed = 10f; // Running speed when close to the player
>>>>>>> Stashed changes
    public float detectionDistance = 5f; // Distance at which the enemy starts running
    public float selfDestructDelay = 1.5f; // Time delay before self-destructing

    private float currentSpeed;
    private bool isRunning = false;
<<<<<<< Updated upstream
=======
    private NavMeshAgent agent;


>>>>>>> Stashed changes

    void Start()
    {
        currentSpeed = walkSpeed;
<<<<<<< Updated upstream
=======

        agent = GetComponent<NavMeshAgent>();

        player = GameObject.FindGameObjectWithTag("Player").transform; 
        
>>>>>>> Stashed changes
    }

    void Update()
    {
<<<<<<< Updated upstream
=======
        //Move towards the player
        agent.SetDestination(player.position);


       
>>>>>>> Stashed changes
        // Check if the player is not null (exists)
        if (player != null)
        {
            // Calculate distance to the player
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            // Walk towards the player
<<<<<<< Updated upstream
            transform.position = Vector3.MoveTowards(transform.position, player.position, currentSpeed * Time.deltaTime);

            // Rotate to face the player
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
=======
          //  transform.position = Vector3.MoveTowards(transform.position, player.position, currentSpeed * Time.deltaTime);

            // Rotate to face the player
            Vector3 direction = player.position - transform.position;
           // float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
           // transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
>>>>>>> Stashed changes

            // Check if the enemy should start running
            if (distanceToPlayer <= detectionDistance && !isRunning)
            {
                isRunning = true;
<<<<<<< Updated upstream
                currentSpeed = runSpeed;
=======
                agent.speed = runSpeed;
>>>>>>> Stashed changes
                Invoke("SelfDestruct", selfDestructDelay);
            }
        }
    }

    void SelfDestruct()
    {
        // Implement self-destruct behavior here (e.g., particle effects, damage to player, etc.)
        Destroy(gameObject);
    }
}
