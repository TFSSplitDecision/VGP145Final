using UnityEngine;

[CreateAssetMenu(fileName = "Ammo", menuName = "Data/Ammo", order = 1)]
public class Ammo : BaseItem
{
    [SerializeField]
    private int amount = 1;
    public int getAmount => amount;
}
