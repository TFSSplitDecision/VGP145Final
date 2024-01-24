using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tankbehaivour : MonoBehaviour
{
    [SerializeField] Transform target; 
    [SerializeField] float speed;
    [SerializeField] float turnSpeed;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = new Vector3(target.position.x, 0, target.position.z);
        Vector3 targetDir = (targetPos - new Vector3(transform.position.x, 0, transform.position.z)).normalized;

        float singleStep = turnSpeed * Time.deltaTime;
        Vector3 turnDir = Vector3.RotateTowards(transform.forward, targetDir, singleStep, 0.0f);
        Debug.DrawRay(transform.position, 10*turnDir, Color.red);

        //transform.Translate(speed * Time.deltaTime * targetDir);
        rb.velocity = speed * targetDir;
        transform.rotation = Quaternion.LookRotation(turnDir);
    }
}
