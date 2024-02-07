using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTestScript : MonoBehaviour
{

    public GameObject bulletPrefab;

    public BulletManager bulletManager;
    public float testInterval = 2f; // Time in seconds between test bullet spawns
    public float bulletSpeed = 10f;
    public int bulletDamage = 1;
    public string ownerTag = "Player";

    private float testTimer;
    private int testPhase = 0;

    private void Start()
    {
        if (bulletManager == null)
        {
            Debug.LogError("BulletManager reference not set in BulletTest.");
            return;
        }

        testTimer = 0f;
    }

    private void Update()
    {
        testTimer += Time.deltaTime;

        if (testTimer >= testInterval)
        {
            testTimer = 0f;
            FireTestBullet();
        }
    }

    private void FireTestBullet()
    {
        Vector3 direction = Vector3.zero;

        switch (testPhase)
        {
            case 0:
                direction = Vector3.right;
                break;
            case 1:
                direction = Vector3.left;
                break;
            case 2:
                direction = Vector3.forward;
                break;
            case 3:
                direction = Vector3.back;
                break;
        }

        bulletManager.SpawnBullet(direction, bulletPrefab, bulletDamage);

        testPhase = (testPhase + 1) % 4; // Cycle through test phases
    }

}
