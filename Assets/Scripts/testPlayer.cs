using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPlayer : MonoBehaviour
{
    [SerializeField] float speed;
    //Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxisRaw("Horizontal");
        float fInput = Input.GetAxisRaw("Vertical");
        Vector3 moveDir = new Vector3(hInput, 0, fInput).normalized;

        transform.Translate(speed *Time.deltaTime* moveDir.x, 0, speed *Time.deltaTime * moveDir.z);
        //rb.velocity = speed * moveDir;
    }
}
