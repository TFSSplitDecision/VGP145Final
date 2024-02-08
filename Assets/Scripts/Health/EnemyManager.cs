using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private DropData itemDrops;

    private EnemyHealthBar healthBar;
    private float currentHealth;
    public float health => currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar = GetComponentInChildren<EnemyHealthBar>();
        if (!healthBar) Debug.Log("No Health Bar reference");
        if (!itemDrops) Debug.Log("No Drop Data given for enemy");
    }

    public void LoseHealth(float healthChange)
    {
        currentHealth -= healthChange;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBar.UpdateHealthBar(currentHealth, maxHealth);

        if (currentHealth <= 0)
            EnemyDeath();
    }

    private void EnemyDeath()
    {
        DropItem();
        DeathEffect();
        Destroy(gameObject);
    }

    private void DropItem()
    {
        Debug.Log("Item Drop not implemented");
        //itemDrops.DropAt(transform);
    }

    private void DeathEffect()
    {
        Debug.Log("Death Effect not implemented");
    }

}
