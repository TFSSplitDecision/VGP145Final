using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/Shotgun", order = 12)]
public class Shotgun : Arm1
{
    [Header("Shotgun Only")]
    [SerializeField]
    private int m_spread = 60;
    [SerializeField]
    private int m_projectiles = 7;
    protected override void primaryFireScript()
    {
        Debug.Log("Shotgun go Boom");
    }

    public int spread => m_spread;

    public int projectiles => m_projectiles;
}
