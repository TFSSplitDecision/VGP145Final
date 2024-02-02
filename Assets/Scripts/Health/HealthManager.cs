using UnityEngine;

public class HealthManager : MonoBehaviour
{
    //protected HealthValue health;
    [SerializeField] protected float health;
    [SerializeField, SceneEditOnly] protected float baseMaxHealth = 100;
    [SerializeField, ReadOnly] private float actualMaxHealth = 100;
    [HideInInspector] protected float healthChange;

    private static HealthManager playerHealthManager;

    public static float playerHealth => (playerHealthManager.health / playerHealthManager.actualMaxHealth) * 100;



    // Caching components
    protected InventoryManager inventoryManager;


    private void Start()
    {
        // Cache inventory manager
        inventoryManager = GetComponent<InventoryManager>();

        actualMaxHealth = baseMaxHealth;


        if( gameObject.CompareTag("Player") )
        {
            playerHealthManager = this;
        }

    }

    public void RestoreHealth()
    {
        health = actualMaxHealth;
    }

    public void GainHealth(float healthChange)
    {
        health += healthChange;

        if (health > actualMaxHealth) health = actualMaxHealth;
    }

    public void LoseHealth(float healthChange)
    {
        health -= healthChange;

        if (health < 0) health = 0;
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
            actualMaxHealth = (baseMaxHealth*maxMult) + maxAdd;
        }

        // Ensure that health never goes above its limit
        health = Mathf.Clamp(health, 0, actualMaxHealth);
    }

}
