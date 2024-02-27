using UnityEngine;

public class SuicideBomberRefactored : EnemyBase
{
    public float selfDestructDelay = 1.5f; // Time delay before self-destructing
    public bool isRunning = false; 
    public float runSpeed = 10f;


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        OnPlayerSpotted += Attack;
        OnPlayerOutOfRange += StopAttack;
    }

    // Update is called once per frame
    void Update()
    {
        FacePlayer();
        
            // Calculate distance to the player
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);


            // Check if the enemy should start running
            if (distanceToPlayer <= attackDist)
            {
                //isAttacking = true; 
                isRunning = true;
                baseSpeed = runSpeed;
                Invoke("SelfDestruct", selfDestructDelay);
            }
    }
    
    void SelfDestruct()
    {
        Debug.Log("Explode");
        // Implement self-destruct behavior here (e.g., particle effects, damage to player, etc.)
        Destroy(gameObject);
    }

    protected override void FacePlayer()
    {
        if (isAttacking)
            base.FacePlayer();
    }

    protected override void Attack()
    {
        base.Attack();
        if (!isAttacking)
        {
            isAttacking = true;
        }
    }

    protected override void StopAttack()
    {
        base.StopAttack();
        if (isAttacking)
        {
            isAttacking = false;
        }
    }
}
