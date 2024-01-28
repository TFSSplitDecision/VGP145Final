using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/RocketBoots", order = 10)]
public class RocketBoots : Legs
{
    protected override void LegsAbilityScript()
    {
        Debug.Log("No Special Ability!");
    }
}
