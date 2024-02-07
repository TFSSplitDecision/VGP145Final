using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private BulletData m_data;



    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        body.AddForce(transform.forward * m_data.speed, ForceMode.VelocityChange);

        // Destroy bullet after a certain amount of time
        float lifetime = m_data.lifetime;
        Destroy(gameObject, lifetime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Note: Hurting will be handled with a diffent script
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Bullet hit a wall");
        }
        Destroy(gameObject);
    }
}
