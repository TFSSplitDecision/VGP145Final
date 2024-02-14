using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShootManager : MonoBehaviour
{
    [SerializeField] private Arm1 m_primary;
    [SerializeField] private Arm2 m_secondary;
    [SerializeField] private Transform m_shootPoint;
    [SerializeField] private LaserShot m_laserShot;

    private InventoryManager invM;

    void Start()
    {
        //need to null check A1 somehow
        invM = FindObjectOfType<InventoryManager>();
        if (!invM) Debug.Log("Shoot Manager can't find the Inventory Manager");

        m_bulletSpawner = new BulletSpawner(gameObject, m_shootPoint);
        singleShot = new SingleShot(gameObject, m_bulletSpawner);
        spreadShot = new SpreadShot(gameObject, m_bulletSpawner);
        

        m_lastFire1 = 100.0f;
        m_lastFire2 = 100.0f;
    }


    //DefaultPistol
    //SMG
    //Shotgun
    //SniperRifle
    public void LeftClickFire()
    {
        //Debug.Log("Left Click is Being Held");
        
        if (a1CurEquip is DefaultPistol)
        {
            Debug.Log("Pistol is Equipped");
            //pass the cur equip to the Single Shot script
        }

        if (a1CurEquip is SMG)
        {
            Debug.Log("SMG is Equipped");
            //pass the cur equip to the Single Shot script
        }

        if (a1CurEquip is SniperRifle)
        {
            Debug.Log("Sniper is Equipped");
            //pass the cur equip to the Single Shot script
        }


        // Fire Rate Check
        float fireRate = (shotData.fireRate / speedMult) - speedAdd;
        fireRate = Mathf.Clamp(fireRate, 0.05f, 3.0f);
        if (lastFire < fireRate)  return;
        
        // Modify Damage
        float damage = (weapon.flatDamage * attackMult) +attackAdd;


        // Special case for laser weapon
        if (weapon is Laser)
        {
            m_laserShot.Shoot(damage);
            return;
        }

        // Select the right shot mechanics
        BaseShot shot = singleShot;
        float spreadAngle = shotData.spreadAngle;
        if (spreadAngle > 5.0f) shot = spreadShot;

        if (a1CurEquip is Shotgun)
        {
            Debug.Log("Shotgun is Equipped");
            //pass the cur equip to the Spread Shot script
        }

        else
        {
            Debug.Log("ShootManager is unaware what Arm 1 is equipped");
        }
    }

    void UpdateEquippedA1(Arm1 incoming)
    {
        a1CurEquip = incoming;
    }
}
