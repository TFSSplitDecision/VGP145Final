using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Progress;

[RequireComponent(typeof(Collector))]
public class InventoryManager : MonoBehaviour {

    [SerializeField,SceneEditOnly]
    private Helmet helmetSlot;
    [SerializeField, SceneEditOnly]
    private Arm1 arm1Slot;
    [SerializeField, SceneEditOnly]
    private Arm2 arm2Slot;
    [SerializeField, SceneEditOnly]
    private Chest chestSlot;
    [SerializeField, SceneEditOnly]
    private Legs legsSlot;

    private List<Equipment> allEquipment;

    
    private HealthManager healthManager;
    private ShootManager shootManager;

    void Start() {
        
        healthManager = GetComponent<HealthManager>();
        shootManager = GetComponent<ShootManager>();

        shootManager.Equip(arm1Slot);
        shootManager.Equip(arm2Slot);

        UpdateEquipment();
    }

    // Update is called once per frame
    void Update() {
        
    }

    protected void Drop(Equipment equip)
    {
        if (equip == null) return;

        Vector3 dropPoint = transform.position;
        var dropPrefab = equip.dropPrefab;
        if (dropPrefab != null)
            Instantiate(dropPrefab, dropPoint, Quaternion.identity);
    }


    private void UpdateEquipment()
    {
        allEquipment = new List<Equipment>() { helmetSlot, arm1Slot, arm2Slot, chestSlot, legsSlot };
        allEquipment.RemoveAll(e => e == null);
    }

    public void Pickup(Equipment equip)
    {

        if (equip is Helmet)
        {
            Drop(helmetSlot);
            helmetSlot = equip as Helmet;
        }
        else if (equip is Arm1)
        {
            Drop(arm1Slot);
            arm1Slot = equip as Arm1;
        }
        else if (equip is Arm2)
        {
            Drop(arm2Slot);
            arm2Slot = equip as Arm2;
        }
        else if (equip is Chest)
        {
            Drop(chestSlot);
            chestSlot = equip as Chest;
        }
        else if (equip is Legs)
        {
            Drop(legsSlot);
            legsSlot = equip as Legs;
        }

        // Update weapon on the shoot manager
        if( equip is Weapon )
            shootManager.Equip(equip as Weapon);

        // Initialize the equipment
        // Set its owner to this gameobject
        equip.Init(gameObject);

        // Update All Equipment List
        UpdateEquipment();
    }
    public void Pickup(BaseItem item) 
    {
        if( item is Equipment )
        {
            Pickup(item as Equipment);
        }
        else if (item is Ammo)
        {
            if (arm2Slot == null) return;

            Ammo ammo = item as Ammo;
            arm2Slot.gainAmmo(ammo.getAmount);
        }
        else if( item is HealingItem )
        {
            HealingItem healingItem = item as HealingItem;
            if (healthManager != null) healthManager.GainHealth(healingItem.amount);
        }
    }


    public int getCurrentAmmo()
    {
        if (arm2Slot == null) return 0;
        return arm2Slot.ammo;
    }

    public int getMaxAmmo()
    {
        if (arm2Slot == null) return 0;
        return arm2Slot.maxAmmo;
    }


    public float getHealthMultiply() { return allEquipment.Aggregate(1f, (acc, cur) => acc *= cur.getHealthMultiply()); }
    public int getHealthAdd() { return allEquipment.Aggregate(0, (acc, cur) => acc += cur.getHealthAdd()); }
    public float getAttackSpeedMultiply() { return allEquipment.Aggregate(1f, (acc, cur) => acc *= cur.getAttackSpeedMultiply()); }
    public int getAttackSpeedAdd() { return allEquipment.Aggregate(0, (acc, cur) => acc += cur.getAttackSpeedAdd()); }
    public float getAttackDamageMultiply() { return allEquipment.Aggregate(1f, (acc, cur) => acc *= cur.getAttackDamageMultiply()); }
    public int getAttackDamageAdd() { return allEquipment.Aggregate(0, (acc, cur) => acc += cur.getAttackDamageAdd()); }
    public float getMoveSpeedMultiply() { return allEquipment.Aggregate(1f, (acc, cur) => acc *= cur.getMoveSpeedMultiply()); }
    public int getMoveSpeedAdd() { return allEquipment.Aggregate(0, (acc, cur) => acc += cur.getMoveSpeedAdd()); }
    public float getDamageReductionMultiply() { return allEquipment.Aggregate(1f, (acc, cur) => acc *= cur.getDamageReductionMultiply()); }
    public int getDamageReductionAdd() { return allEquipment.Aggregate(0, (acc, cur) => acc += cur.getDamageReductionAdd()); }
    public Sprite getHelmetSprite() => helmetSlot == null ? null : helmetSlot.getSprite();
    public Sprite getArm1Sprite() => arm1Slot == null ? null : arm1Slot.getSprite();
    public Sprite getArm2Sprite() => arm2Slot == null ? null : arm2Slot.getSprite();
    public Sprite getChestSprite() => chestSlot == null ? null : chestSlot.getSprite();
    public Sprite getLegsSprite() => legsSlot == null ? null : legsSlot.getSprite();
}
