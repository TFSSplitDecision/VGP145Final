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

    private void OnTriggerEnter(Collider other)
    {
        // Ignore objects with the same tags
        if( other.CompareTag(gameObject.tag) )
        {
            return;
        }

        Destroy(gameObject);
    }
}
