using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTestScript : MonoBehaviour
{
    BulletManager bm;
    public int bulletCount;
    // Start is called before the first frame update
    void Start()
    {
        bm = GetComponent<BulletManager>();
        bulletCount = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (bulletCount > 0)
            bm.SpawnBullet(new Vector3(1, 0, 1), 5, 5, "Enemy");
        bulletCount--;
    }
}
