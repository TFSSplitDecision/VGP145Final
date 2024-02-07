using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "BulletData", menuName = "Data/Bullet(Data)", order = 1)]
public class BulletData : ScriptableObject
{

    [SerializeField, Tooltip("How fast the bullet will be travelling")]
    private float m_speed = 10.0f;

    [SerializeField, Tooltip("The damage caused by the bullet")]
    private float m_damage = 1.0f;

    [SerializeField, Tooltip("How long the bullet is alive")]
    private float m_lifetime = 5.0f;


    #region Getters
    public float speed => m_speed;
    public float damage => m_damage;
    public float lifetime => m_lifetime;

    #endregion

}
