using UnityEngine;

public class HealthManager : MonoBehaviour
{
    //protected HealthValue health;
    [SerializeField] private float m_health;
    public float health => m_health;


    [SerializeField, SceneEditOnly] protected float m_baseMaxHealth = 100;
    [SerializeField, ReadOnly] private float m_actualMaxHealth = 100;

    public float maxHealth => m_actualMaxHealth;


    [HideInInspector] protected float healthChange;

    private static HealthManager playerHealthManager;


    public static float playerHealth => playerHealthManager.health;
    public static float playerMaxHealth => playerHealthManager.maxHealth;



    // Caching components
    protected InventoryManager inventoryManager;


    private void Start()
    {
        
        // Cache inventory manager
        inventoryManager = GetComponent<InventoryManager>();

        m_actualMaxHealth = m_baseMaxHealth;
        RestoreHealth();

        if( gameObject.CompareTag("Player") )
        {
            playerHealthManager = this;
        }

    }

    public void RestoreHealth()
    {
        m_health = m_actualMaxHealth;
    }

    public void GainHealth(float healthChange)
    {
        m_health += healthChange;

        if (health > m_actualMaxHealth) m_health = m_actualMaxHealth;
    }

    public void LoseHealth(float healthChange)
    {
        m_health -= healthChange;

        if (health < 0) m_health = 0;
    }

    public float GetHealth()
    {
        return health;
    }

    protected void Update()
    {
        // Polling used here is a quick fix, but is a bad solution overall.
        // TODO: grab health modifiers only when there's a change in the inventory
        if( inventoryManager != null )
        { 
            float maxAdd = inventoryManager.getHealthAdd();
            float maxMult = inventoryManager.getHealthMultiply();
            m_actualMaxHealth = (m_baseMaxHealth * maxMult) + maxAdd;
        }

        // Ensure that health never goes above its limit
        m_health = Mathf.Clamp(health, 0, m_actualMaxHealth);
    }

}
