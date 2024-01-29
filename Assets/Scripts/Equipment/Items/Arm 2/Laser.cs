using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/Laser", order = 15)]
public class Laser : Arm2
{
    [Header("Laser")]
    [SerializeField]
    protected float duration = 5;
    protected override void secondaryFireScript()
    {
        Debug.Log("Laser go zing shwooom POG");
    }
}
