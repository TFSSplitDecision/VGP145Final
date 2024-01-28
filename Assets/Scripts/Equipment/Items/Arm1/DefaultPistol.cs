using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/DefaultPistol", order = 4)]
public class DefaultPistol : Arm1
{
    protected override void primaryFireScript()
    {
        Debug.Log("Fire!");
    }
}
