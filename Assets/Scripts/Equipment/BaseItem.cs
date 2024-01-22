using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseItem : ScriptableObject
{

    private GameObject player;
    public Sprite icon;
    public virtual void Init(GameObject player)
    {
        this.player = player;
    }

}


[CreateAssetMenu(fileName = "Ammo", menuName = "Data/Ammo", order = 4)]
public class Ammo : BaseItem
{
    InventoryManager inventoryManager;

    [SerializeField]
    private int amount = 1;

    public int getAmount => amount;

}
