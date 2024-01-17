using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    // This is the bullet prefab, don't forget to assign the bullet prefab to the bullet manager object.
    public GameObject bulletPrefab;


    // (Vector 3 dir, float speed, int damage, string owner) -> SpawnBullet

    // Dir is a vector that specifies where the bullet will travel to, the spawn script will normalize it
    // automatically, so you simply need to pass in the destination coordinates.

    // Speed is the travel speed of the bullet, if negative numbers are passed in, default value of 1 will
    // be applied

    // Damage is the damage of the bullet, if negative numbers are passed in, default value of 1 will be 
    // applied

    // Owner specifies who fired the bullet, please only use values "Enemy" or "Player".
    public void SpawnBullet(Vector3 dir, float speed, int damage, string owner)
    {
        try
        {
            if (bulletPrefab == null)
            {
                // Error checking for whether the bullet prefab is assigned
                throw new System.Exception("Bullet prefab is not assigned in BulletManager");
            }
            
            // Creates the bullet
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            // Gets the bullet script
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            if (bulletScript != null)
            {
                // Assigns the values of the bullet
                bulletScript.direction = dir;
                bulletScript.speed = speed;
                bulletScript.damage = damage;
                bulletScript.owner = owner;
                bulletScript.lifetime = 5f;
            }
            else
            {
                // Error checking for whether the bullet script is assigned
                throw new System.Exception("Bullet script not assigned on the bullet prefab");
            }
        }
        catch (System.Exception e)
        {
            // Catches any other errors that may occur
            Debug.LogError("BulletManager SpawnBullet encountered an error: " + e.Message);
        }
    }
}
