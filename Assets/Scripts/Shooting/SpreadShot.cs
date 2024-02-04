using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadShot : MonoBehaviour
{
    public Shotgun shotgunData;
    public BulletManager bulletManager;
    public BulletData bulletData;

    
    public void Shoot(Shotgun shotgunData, float damage)
    {
        float stepAngle = shotgunData.spread / (shotgunData.projectiles - 1);
        float fullAngle = -shotgunData.spread / 2f;

        for (int i = 0; i < shotgunData.projectiles; i++)
        {
            Quaternion bulletRotation = Quaternion.Euler(0f, fullAngle + stepAngle * i, 0f);
            Vector3 bulletDirection = bulletRotation * transform.forward;

            int damageInt = Mathf.RoundToInt(damage);
            //damage = shotgunData.bullet.damage;
            bulletManager.SpawnBullet(bulletDirection, shotgunData.bullet.speed, damageInt, "Player");
        }

        
    }
        
}
