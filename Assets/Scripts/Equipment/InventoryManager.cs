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

    [SerializeField,ReadOnly]
    private Helmet helmetSlot;
    [SerializeField, ReadOnly]
    private Arm1 arm1Slot;
    [SerializeField, ReadOnly]
    private Arm2 arm2Slot;
    [SerializeField, ReadOnly]
    private Chest chestSlot;
    [SerializeField, ReadOnly]
    private Legs legsSlot;

    private List<Equipment> allEquipment;


    /// <summary>
    /// Notifies all subscribed scripts that the Arm1 slot has changed.
    /// And it passes the Arm1 object to the subscribed scripts.
    /// </summary>
    [SerializeField, ReadOnly]
    private UnityEvent<Arm1> m_onArm1Change;
    public UnityEvent<Arm1> onArm1Change => m_onArm1Change;

    /// <summary>
    /// Notifies all subscribed scripts that the Arm2 slot has changed.
    /// And it passes the Arm2 object to the subscribed scripts.
    /// </summary>
    [SerializeField, ReadOnly]
    private UnityEvent<Arm2> m_onArm2Change;
    public UnityEvent<Arm2> onArm2Change => m_onArm2Change;


    void Start() {
        
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
            if (m_onArm1Change != null)
                m_onArm1Change.Invoke(arm1Slot);
        }
        else if (equip is Arm2)
        {
            Drop(arm2Slot);
            arm2Slot = equip as Arm2;
            if (m_onArm2Change != null)
                m_onArm2Change.Invoke(arm2Slot);
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

        // Initialize the equipment
        // Set its owner to this gameobject
        equip.Init(gameObject);

        // Update All Equipment List
        allEquipment = new List<Equipment>() { helmetSlot, arm1Slot, arm2Slot, chestSlot, legsSlot };
        allEquipment.RemoveAll(e => e == null);
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
