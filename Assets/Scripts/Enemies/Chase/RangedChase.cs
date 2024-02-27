using UnityEngine;
using UnityEngine.AI;

public class RangedChase : MonoBehaviour
{
    public Transform player;
    public float range = 10;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //go to a distance from player
        move();
        //Priority Behaviour, keep a certain distance from player

            //if got too close, distance away

        // when on desirable distance shoot

            //shooting script accuracy
    }

    void move()
    {
        Vector3 distance = (transform.position - player.position);
        distance.x = Mathf.Abs(distance.x);
        distance.z = Mathf.Abs(distance.y);
        float currDistance = Mathf.Sqrt(distance.x * distance.x + distance.z * distance.z);

        if (currDistance >= range)
        {       
            //if outside of radius, go to player
            agent.SetDestination(player.position);
        }
        else
        {
            //stops once within range
            agent.SetDestination(transform.position);
        }

    }

    void shoot()
    {

    }
}
