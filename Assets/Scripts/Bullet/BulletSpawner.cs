using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A utility for spawning bullets.
/// This will be part of the ShootManager script.
/// </summary>
public class BulletSpawner
{

    // This is where the bullet gets spawned from
    private Transform m_origin;

    // This is the gameobject that uses this bullet spawner
    private GameObject m_owner;


    /// <summary>
    /// 
    /// </summary>
    /// <param name="owner">The gameobject that 'owns' the bullet spawner</param>
    /// <param name="origin">The point where the bullet starts from</param>
    public BulletSpawner( GameObject owner, Transform origin )
    {
        m_origin = origin;
        m_owner = owner;
    }

    /// <summary>
    /// Spawns a bullet and fires it at a direction.
    /// </summary>
    /// <param name="dir">A vector that specifies where the bullet will travel to</param>
    /// <param name="prefab">The type of bullet to spawn</param>
    /// <param name="damage">The damage inflicted by the bullet</param>
    public void SpawnBullet(Vector3 dir, GameObject prefab, float damage)
    {
        // Get data
        Vector3 spawnPoint = m_origin.position;
        Quaternion spawnRotation = Quaternion.LookRotation(dir, Vector3.up);

        // Creates the bullet
        GameObject bullet = GameObject.Instantiate(prefab, spawnPoint, spawnRotation);

        // Give the bullet your tag, so it discerns what to hurt
        bullet.tag = m_owner.tag;

        // TODO: Get HurtBox and set damage
        Hurtbox hurtbox = bullet.GetComponent<Hurtbox>();
        if( hurtbox != null )
            hurtbox.damage = damage;
        
    }

}
