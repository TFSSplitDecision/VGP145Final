using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/StunGun", order = 14)]
public class StunGun : Arm2
{
    [Header("StunGun Only")]
    [SerializeField]
    protected float Stun_AOE = 10;
    protected override void secondaryFireScript()
    {
        Debug.Log("StunGun go BZZZZ");
    }
}
