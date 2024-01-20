using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/InvisibilityCloak", order = 9)]
public class InvisibilityCloak : Chest
{
    protected override void ChestAbilityScript()
    {
        Debug.Log("Every 10 seconds player becomes untargetable by enemies for 3 seconds!");
    }
}
