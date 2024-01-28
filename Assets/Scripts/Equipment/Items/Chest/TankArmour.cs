using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/TankArmour", order = 7)]
public class TankArmour : Chest
{
    protected override void ChestAbilityScript()
    {
        Debug.Log("No Special Ability!");
    }
}
