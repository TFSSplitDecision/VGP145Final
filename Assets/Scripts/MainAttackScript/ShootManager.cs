using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShootManager : MonoBehaviour
{
    Arm1 a1CurEquip;

    private InventoryManager invM;

    void Start()
    {
        //need to null check A1 somehow
        invM = FindObjectOfType<InventoryManager>();
        if (!invM) Debug.Log("Shoot Manager can't find the Inventory Manager");

        invM.onArm1Change.AddListener(UpdateEquippedA1);
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
