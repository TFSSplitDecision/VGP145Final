using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This will become part of the Player class at a future point, I presume
public class MainAttack : MonoBehaviour
{
    ShootManager shoom;
    void Start()
    {
        shoom = FindObjectOfType<ShootManager>();
        if (!shoom) Debug.Log("Missing the Shoot Manager component");
    }
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            shoom.PrimaryFire();
        }
    }
}
