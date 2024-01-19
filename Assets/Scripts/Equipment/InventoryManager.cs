using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;

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

    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }
    public void pickup(Equipment equip) {
        // TODO: Drop the previously equipped item
        if (equip is Helmet)
            helmetSlot = equip as Helmet;
        else if (equip is Arm1)
            arm1Slot = equip as Arm1;
        else if (equip is Arm2)
            arm2Slot = equip as Arm2;
        else if (equip is Chest)
            chestSlot = equip as Chest;
        else if (equip is Legs)
            legsSlot = equip as Legs;
    }

    private List<Equipment> getAllEquipped() {
        // Hm... my laziness is going to be a doomed scenario...
        return new List<Equipment> { helmetSlot, arm1Slot, arm2Slot, chestSlot, legsSlot };
    }
    public float getHealthMultiply() { return getAllEquipped().Aggregate(1f, (acc, cur) => acc *= cur.getHealthMultiply()); }
    public int getHealthAdd() { return getAllEquipped().Aggregate(0, (acc, cur) => acc += cur.getHealthAdd()); }
    public float getAttackSpeedMultiply() { return getAllEquipped().Aggregate(1f, (acc, cur) => acc *= cur.getAttackSpeedMultiply()); }
    public int getAttackSpeedAdd() { return getAllEquipped().Aggregate(0, (acc, cur) => acc += cur.getAttackSpeedAdd()); }
    public float getAttackDamageMultiply() { return getAllEquipped().Aggregate(1f, (acc, cur) => acc *= cur.getAttackDamageMultiply()); }
    public int getAttackDamageAdd() { return getAllEquipped().Aggregate(0, (acc, cur) => acc += cur.getAttackDamageAdd()); }
    public float getMoveSpeedMultiply() { return getAllEquipped().Aggregate(1f, (acc, cur) => acc *= cur.getMoveSpeedMultiply()); }
    public int getMoveSpeedAdd() { return getAllEquipped().Aggregate(0, (acc, cur) => acc += cur.getMoveSpeedAdd()); }
    public float getDamageReductionMultiply() { return getAllEquipped().Aggregate(1f, (acc, cur) => acc *= cur.getDamageReductionMultiply()); }
    public int getDamageReductionAdd() { return getAllEquipped().Aggregate(0, (acc, cur) => acc += cur.getDamageReductionAdd()); }
}
