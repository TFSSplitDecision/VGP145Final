using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
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

        // Initialize the equipment
        // Set its owner to this gameobject
        equip.Init(gameObject);
    }
}
