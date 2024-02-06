using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleShot : BaseShot
{
    // Note: Ask Danny if we should just remove this
    // This is just for the sake of having the name of "SingleShot" available
    public SingleShot(GameObject owner, BulletSpawner bulletSpawner) : base(owner, bulletSpawner)
    {
    }
}
