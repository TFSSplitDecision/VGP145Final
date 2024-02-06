using UnityEngine;

public class HealthManager : MonoBehaviour
{
    //protected HealthValue health;
<<<<<<< Updated upstream
    [SerializeField] protected float health;
    [SerializeField, SceneEditOnly] protected float baseMaxHealth = 100;
    [SerializeField, ReadOnly] private float actualMaxHealth = 100;
=======
    [SerializeField] private float m_health;
    public float health => m_health;


    [SerializeField, SceneEditOnly] protected float m_baseMaxHealth = 100;
    [SerializeField, ReadOnly] private float m_actualMaxHealth = 100;

    public float maxHealth => m_actualMaxHealth;


>>>>>>> Stashed changes
    [HideInInspector] protected float healthChange;

    private static HealthManager playerHealthManager;

<<<<<<< Updated upstream
    public static float playerHealth => (playerHealthManager.health / playerHealthManager.actualMaxHealth) * 100;
=======

    public static float playerHealth => playerHealthManager.health;
    public static float playerMaxHealth => playerHealthManager.maxHealth;
>>>>>>> Stashed changes



    // Caching components
    protected InventoryManager inventoryManager;


    private void Start()
    {
<<<<<<< Updated upstream
        // Cache inventory manager
        inventoryManager = GetComponent<InventoryManager>();

        actualMaxHealth = baseMaxHealth;
=======
        
        // Cache inventory manager
        inventoryManager = GetComponent<InventoryManager>();

        m_actualMaxHealth = m_baseMaxHealth;
>>>>>>> Stashed changes


        if( gameObject.CompareTag("Player") )
        {
            playerHealthManager = this;
        }

    }

    public void RestoreHealth()
    {
<<<<<<< Updated upstream
        health = actualMaxHealth;
=======
        m_health = m_actualMaxHealth;
>>>>>>> Stashed changes
    }

    public void GainHealth(float healthChange)
    {
<<<<<<< Updated upstream
        health += healthChange;

        if (health > actualMaxHealth) health = actualMaxHealth;
=======
        m_health += healthChange;

        if (health > m_actualMaxHealth) m_health = m_actualMaxHealth;
>>>>>>> Stashed changes
    }

    public void LoseHealth(float healthChange)
    {
<<<<<<< Updated upstream
        health -= healthChange;

        if (health < 0) health = 0;
=======
        m_health -= healthChange;

        if (health < 0) m_health = 0;
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
            actualMaxHealth = (baseMaxHealth*maxMult) + maxAdd;
        }

        // Ensure that health never goes above its limit
        health = Mathf.Clamp(health, 0, actualMaxHealth);
=======
            m_actualMaxHealth = (m_baseMaxHealth * maxMult) + maxAdd;
        }

        // Ensure that health never goes above its limit
        m_health = Mathf.Clamp(health, 0, m_actualMaxHealth);
>>>>>>> Stashed changes
    }

}
