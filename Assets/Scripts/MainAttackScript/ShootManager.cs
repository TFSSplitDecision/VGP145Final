using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager : MonoBehaviour
{
    Arm1 a1CurEquip;

    private InventoryManager invM;

    // Start is called before the first frame update
    void Start()
    {
        //need to null check A1 somehow
        invM = FindObjectOfType<InventoryManager>();
        if (!invM) Debug.Log("Shoot Manager can't find the Inventory Manager");


        invM.onArm1Change.AddListener(UpdateEquippedA1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LeftClickFire()
    {
        Debug.Log("Left Click is Being Held");
        //Would like to check data of currently equipped arm1 to know which relevent shoot script to pass it to
    }

    void UpdateEquippedA1(Arm1 incoming)
    {
        a1CurEquip = incoming;
    }
}
