using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/Shotgun", order = 12)]
public class Shotgun : Arm1
{
    [Header("Shotgun Only")]
    [SerializeField]
    protected float spread = 60f;
    [SerializeField]
    protected float projectiles = 7;
    protected override void primaryFireScript()
    {
        Debug.Log("Shotgun go Boom");
    }
}
