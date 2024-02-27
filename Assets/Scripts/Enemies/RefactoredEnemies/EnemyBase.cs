using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(EnemyManager), typeof(EnemyHitbox))]
public class EnemyBase : MonoBehaviour
{
    [SerializeField] protected float baseSpeed = 3;
    [SerializeField] float turnSpeed = 120;
    [SerializeField] float widthOfView = 0.5f;
    [SerializeField] protected float attackDist = 1.5f;

    protected NavMeshAgent agent;
    protected Animator anim;
    protected Transform player;
    protected event Action OnPlayerSpotted;
    protected event Action OnPlayerOutOfRange;
    public bool isAttacking;


    // Start is called before the first frame update
    protected virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (!agent) Debug.Log("No NavMeshAgent attached");
        if (!anim) Debug.Log("No Animator on enemy model");
        if (!player) Debug.Log("No Player in Scene (or untagged)");

        agent.SetDestination(player.position);
        agent.speed = baseSpeed;
        agent.angularSpeed = turnSpeed;
        agent.stoppingDistance = attackDist;
    }

    protected virtual void FixedUpdate()
    {
        agent.SetDestination(player.position);
        PlayerCheck();
    }

    private void PlayerCheck()
    {
        RaycastHit hitInfo;
        Vector3 pos = transform.position;
        Vector3 halfExtents = transform.localScale * widthOfView;
        Vector3 fwd = transform.forward;
        Quaternion rot = transform.rotation;

        if (Physics.BoxCast(pos, halfExtents, fwd, out hitInfo, rot, attackDist))
        {
            if (hitInfo.collider.CompareTag("Player"))
                OnPlayerSpotted?.Invoke();
        }
        else
        {
            OnPlayerOutOfRange?.Invoke();
        }
    }

    protected virtual void FacePlayer()
    {
        Vector3 targetPos = new Vector3(player.position.x, 0, player.position.z);
        Vector3 targetDir = (targetPos - new Vector3(transform.position.x, 0, transform.position.z)).normalized;

        float singleStep = turnSpeed * Time.deltaTime;
        Vector3 turnDir = Vector3.RotateTowards(transform.forward, targetDir, singleStep, 0.0f);

        transform.rotation = Quaternion.LookRotation(turnDir);
    }

    protected virtual void Attack()
    {
        Debug.Log("Attack not Implemented");
    }

    protected virtual void StopAttack()
    {
        Debug.Log("StopAttack not Implemented");
    }

}
