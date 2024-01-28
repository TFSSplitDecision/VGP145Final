using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/RPG", order = 13)]
public class RPG : Arm2
{
    [Header("RPG Only")]
    [SerializeField]
    protected float AOE_Radius = 10;
    protected override void secondaryFireScript()
    {
        Debug.Log("RPG go Boom");
    }
}
