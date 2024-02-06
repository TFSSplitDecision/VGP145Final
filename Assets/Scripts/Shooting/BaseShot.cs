using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// BaseShot does boiler plate code stuff.
/// Can be used as a single shot.
/// </summary>
public abstract class BaseShot : MonoBehaviour, IShot
{
    protected GameObject m_owner;
    protected BulletManager m_bulletManager;
    protected Transform m_transform;

    public virtual void Init(GameObject owner)
    {
        // Note: This is "upgrade path" stuff ask Christos for more info
        m_owner = owner;
        m_transform = owner.transform;
        m_bulletManager = m_owner.GetComponent<BulletManager>();
    }

    public virtual void Shoot(ShotData shotData, GameObject bullet, float damage)
    {
        Vector3 forward = m_transform.forward;
        m_bulletManager.SpawnBullet(forward, bullet, damage);
    }

    public virtual void Stop()
    {
        // Does nothing here.
    }
}
