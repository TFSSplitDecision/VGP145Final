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
        // Destroy bullet after a certain amount of time
        float lifetime = m_data.lifetime;
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Get data
        Vector3 direction = transform.forward;
        float speed = m_data.speed;

        // This moves the bullet in the direction at the specified speed
        transform.Translate(direction * speed * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        // Ignore anything that is the same tag
        if( other.CompareTag(gameObject.tag))
        {
            return;
        }
        // Otherwise Destroy
        Destroy(gameObject);
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    // Note: Hurting will be handled with a diffent script
    //    if (collision.gameObject.CompareTag("Wall"))
    //    {
    //        Debug.Log("Bullet hit a wall");
    //    }
    //    Destroy(gameObject);
    //}
}
