using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

public class BulletManager : MonoBehaviour
{
    [SerializeField, Tooltip("The point where the bullet gets spawned from")]
    private Transform m_shootPoint;


    private void Start()
    {
        if (m_shootPoint == null)
            m_shootPoint = transform;
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
        Vector3 spawnPoint = m_shootPoint.position;
        Quaternion spawnRotation = Quaternion.LookRotation(dir, Vector3.up);

        // Creates the bullet
        GameObject bullet = Instantiate(prefab, spawnPoint, spawnRotation);

        // Give the bullet your tag, so it discerns what to hurt
        bullet.tag = gameObject.tag;

        // TODO: Get HurtBox and set damage
        // ...
    }
}
