using System.Collections;
using System.Collections.Generic;
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
}
