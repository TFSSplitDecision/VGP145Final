using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/TeleportationBoots", order = 11)]
public class TeleportationBoots : Legs
{
    protected override void LegsAbilityScript()
    {
        Debug.Log("movement speed x 0, player now can only blink to short position away. 2 second delay");
    }
}
