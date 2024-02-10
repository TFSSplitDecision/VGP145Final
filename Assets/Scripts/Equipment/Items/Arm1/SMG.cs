using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/SMG", order = 2)]
public class SMG : Arm1
{
    protected override void primaryFireScript()
    {
        Debug.Log("Fire!");
    }
}
