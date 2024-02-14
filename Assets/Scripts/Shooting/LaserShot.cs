using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShot : BaseShot
{

    private GameObject m_laserObject;
    private LaserController m_laser;

    public LaserShot(GameObject owner, BulletSpawner bulletSpawner) : base(owner, bulletSpawner)
    {
        
    }

    public override void Shoot(ShotData shotData, GameObject laserPrefab, float damage)
    {
        // Try to create the laser if it doesn't exist
        if(m_laser == null)
        {
            GameObject temp = GameObject.Instantiate(laserPrefab, m_transform);
            m_laser = temp.GetComponent<LaserController>();

            if (m_laser == null)
            {
                GameObject.Destroy(temp);
                Debug.LogError("laserPrefab does not contain a laser controller component!");
                return;
            }
        }

        // If it does exist, pass on the damage data
        m_laser.Shoot(damage);
    }

}
