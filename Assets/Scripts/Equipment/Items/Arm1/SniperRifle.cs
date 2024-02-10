using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/SniperRifle", order = 3)]
public class SniperRifle : Arm1
{
    protected override void primaryFireScript()
    {
        Debug.Log("Fire!");
    }
}
