using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleShotScript : MonoBehaviour
{
    public DefaultPistol pistolData;
    public SniperRifle sniperRifleData;
    public SMG SMGData;
    public RPG RPGData;

    public BulletManager bulletManager;
    public BulletData bulletData;

    private bool isShooting = false;

    Coroutine shootCoroutine;

    float fireRate;
    float damage;

    public void pistolShot(DefaultPistol pistolData)
    {
        fireRate = pistolData.bullet.speed;
        Shoot(fireRate, damage);
    }

    public void sniperShot(SniperRifle sniperRifleData)
    {
        fireRate = sniperRifleData.bullet.speed;
        Shoot(fireRate, damage);
    }

    public void SMGShot(SMG SMGData)
    {
        fireRate = SMGData.bullet.speed;
        Shoot(fireRate, damage);
    }

    public void RPGShot(RPG RPGData)
    {
        fireRate = RPGData.bullet.speed;
        Shoot(fireRate, damage);
    }

    //IEnumerator ShootCoroutine(float fireRate, float damage)
    //{
    //    isShooting = true;
    //    Shoot(fireRate,damage);
    //    yield return new WaitForSeconds(1f / fireRate); // Wait for the next shot based on fire rate
    //    isShooting = false;
    //}

    public void Shoot(float fireRate,float damage)
    {
        Vector3 bulletDirection = transform.forward;
        int damageInt = Mathf.RoundToInt(damage);

        bulletManager.SpawnBullet(bulletDirection, fireRate, damageInt, "Player");
    }

    //private void StartShooting(float fireRate, float damage)
    //{
    //    if (shootCoroutine == null)
    //    {
    //        shootCoroutine = StartCoroutine(ShootCoroutine(fireRate, damage));
    //    }
    //}

    //private void StopShooting()
    //{
    //    if (shootCoroutine != null)
    //    {
    //        StopCoroutine(shootCoroutine);
    //    }
    //}
}
