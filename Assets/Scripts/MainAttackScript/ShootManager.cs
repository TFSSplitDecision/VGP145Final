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

    private SingleShot singleShot;
    private SpreadShot spreadShot;
    private BulletSpawner m_bulletSpawner;
    private InventoryManager m_inventory;

    // Live variables
    private float m_lastFire1;
    private float m_lastFire2;

    public void Equip(Weapon weapon)
    {
        if (weapon == null) return;
        if (weapon is Arm1) m_primary = weapon as Arm1;
        if (weapon is Arm2) m_secondary = weapon as Arm2;
    }
    void Start()
    {
        //need to null check A1 somehow
        m_inventory = FindObjectOfType<InventoryManager>();
        if (m_inventory) Debug.Log("Shoot Manager can't find the Inventory Manager");

        m_bulletSpawner = new BulletSpawner(gameObject, m_shootPoint);
        singleShot = new SingleShot();
        spreadShot = new SpreadShot();
        

        m_lastFire1 = 100.0f;
        m_lastFire2 = 100.0f;
    }


    //DefaultPistol
    //SMG
    //Shotgun
    //SniperRifle
    public void LeftClickFire()
    {
        ShotData shotData = m_primary.shotData;

        // Get the modifiers
        float attackMult = 1.0f;
        float attackAdd = 0.0f;
        float speedMult = 1.0f;
        float speedAdd = 0.0f;
        if (m_inventory != null)
        {
            attackMult = m_inventory.getAttackDamageMultiply();
            attackAdd = m_inventory.getAttackDamageAdd();
            speedMult = m_inventory.getAttackSpeedMultiply();
            speedAdd = m_inventory.getAttackSpeedAdd();
        }
        //Debug.Log("Left Click is Being Held");

        if (m_primary is DefaultPistol)
        {
            Debug.Log("Pistol is Equipped");
            //pass the cur equip to the Single Shot script
        }

        if (m_primary is SMG)
        {
            Debug.Log("SMG is Equipped");
            //pass the cur equip to the Single Shot script
        }

        if (m_primary is SniperRifle)
        {
            Debug.Log("Sniper is Equipped");
            //pass the cur equip to the Single Shot script
        }


        // Fire Rate Check
        float fireRate = (shotData.fireRate / speedMult) - speedAdd;
        fireRate = Mathf.Clamp(fireRate, 0.05f, 3.0f);
        if (m_lastFire1 < fireRate)  return;
        
        // Modify Damage
        float damage = (m_primary.flatDamage * attackMult) +attackAdd;


        // Special case for laser weapon
        if (m_secondary is Laser)
        {
            m_laserShot.Shoot(damage);
            return;
        }

        // Select the right shot mechanics
        BaseShot shot = singleShot;
        float spreadAngle = shotData.spreadAngle;
        if (spreadAngle > 5.0f) shot = spreadShot;

        if (m_primary is Shotgun)
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
        m_primary = incoming;
    }
}
