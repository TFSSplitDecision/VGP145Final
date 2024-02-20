using UnityEngine;
using Unity.AI;
using UnityEngine.AI;

public class MeleeChase : MonoBehaviour
{
    public Transform player; 
    public GameObject chaseBullet;

    public float hP;
    public float attackSpeed;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Move towards the player
        agent.SetDestination(player.position);


    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player is inside attack box");
        }
    }
}
