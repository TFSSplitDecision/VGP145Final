using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This will become part of the Player class at a future point, I presume
public class MainAttack : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Debug.Log("Left Click is Being Held");
            //Player will need to connect with heald weapon rate of fire somehow
        }
    }
}
