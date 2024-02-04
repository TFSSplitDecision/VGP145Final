using UnityEngine;

[CreateAssetMenu(fileName = "HealItem", menuName = "Data/HealItem", order = 1)]
public class HealingItem : BaseItem
{
    [SerializeField, Tooltip("Percentage to heal the target")] 
    private float m_amount = 0.3f;

    public float amount => m_amount;
}