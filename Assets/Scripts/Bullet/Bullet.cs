using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    public int damage;
    public string owner;
    public float lifetime;

    // To track how long the bullet has existed for
    private float timeAlive;

    void Start()
    {
        // Normalizes the direction vector
        direction.Normalize();

        // Sets the timer to 0 when bullet spawns
        timeAlive = 0f;
        try
        {
            // Sets default values for if any error occurs
            if (damage <= 0)
            {
                damage = 1;
                throw new System.Exception("Damage is reset to 1");
            }
            if (speed <= 0)
            {
                speed = 1;
                throw new System.Exception("Speed is reset to 1");
            }
            if (lifetime <= 0)
            {
                lifetime = 1;
                throw new System.Exception("Lifetime is reset to 1");
            }
            if (owner != "Enemy" && owner != "Player")
            {
                owner = "Enemy";
                throw new System.Exception("Bullet automatically assigned to enemy");
            }
        }
        catch (System.Exception e)
        {
            // Catches any errors
            Debug.LogError("Bullet encountered an error during initialization: " + e.Message);
        }
    }

    void Update()
    {
        // This moves the bullet in the direction at the specified speed
        transform.Translate(direction * speed * Time.deltaTime);

        // This increments how long the bullet is alive for
        timeAlive += Time.deltaTime;

        // This despawns the bullet if it doesn't hit anything for an extended amount of time
        if (lifetime < timeAlive)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && (owner == "Enemy"))
        {
            // This is where player damage will be tracked, for now, just a console log will be outputed.
            Debug.Log("Bullet hit player for " + damage + " damage");
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy") && (owner == "Player"))
        {
            // This is where enemy damage will be tracked, for now, just a console log will be outputed.
            Debug.Log("Bullet hit enemy for " + damage + " damage");
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Bullet hit a wall");
            Destroy(gameObject);
        }
    }
}
