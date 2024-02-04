using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/AbsorptionArmour", order = 8)]
public class AbsorptionArmour : Chest
{
    protected override void ChestAbilityScript()
    {
        Debug.Log("When hit gain 1 use of special ammo");
    }
}
