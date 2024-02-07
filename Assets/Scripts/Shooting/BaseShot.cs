using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// BaseShot does boiler plate code stuff.
/// Can be used as a single shot.
/// </summary>
public abstract class BaseShot : IShot
{
    protected GameObject m_owner;
    protected BulletSpawner m_bulletSpawner;
    protected Transform m_transform;

    public BaseShot(GameObject owner, BulletSpawner bulletSpawner)
    {
        m_owner = owner;
        m_transform = owner.transform;
        m_bulletSpawner = bulletSpawner;
    }

    public virtual void Shoot(ShotData shotData, GameObject bullet, float damage)
    {
        Vector3 forward = m_transform.forward;
        Debug.Log("Forward: " + forward);
        m_bulletSpawner.SpawnBullet(forward, bullet, damage);
    }

    public virtual void Stop()
    {
        // Does nothing here.
    }
}
