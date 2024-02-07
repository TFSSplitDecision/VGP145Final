using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// A data container that describes the mechanics of the shot.
/// </summary>
[CreateAssetMenu(fileName = "ShotData", menuName = "Data/ShotData", order = 0)]
public class ShotData : ScriptableObject
{

    [SerializeField,Tooltip("How many times to fire per-second")] 
    private float m_fireRate;


    [SerializeField, Range(1,10), Tooltip("Simultaneous rounds fired at once")] 
    private int m_bulletCount = 1;

    [SerializeField, Range(0,90), Tooltip("Spread angle of shot (for shotgun)")] 
    private float m_spreadAngle;



    #region Getters
    public float fireRate => m_fireRate;
    public float spreadAngle => m_spreadAngle;
    public int bulletCount => m_bulletCount;

    #endregion
}
