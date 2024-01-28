using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "BulletData", menuName = "Data/Bullet(Data)", order = 1)]
public class BulletData : ScriptableObject
{

    [SerializeField, Tooltip("The type of bullet to spawn"), SceneEditOnly]
    private GameObject m_prefab;

    [SerializeField, Tooltip("How fast the bullet will be travelling")]
    private float m_speed = 10.0f;

    [SerializeField, Tooltip("The damage caused by the bullet")]
    private float m_damage = 1.0f;

    #region Getters
    public GameObject prefab => m_prefab;
    public float speed => m_speed;
    public float damage => m_damage;

    #endregion

}
