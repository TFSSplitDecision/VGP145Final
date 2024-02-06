using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUDController : MonoBehaviour
{
    private EnemySpawner enemySpawner;
    private HealthManager playerHealth;
    private InventoryManager inventoryManager;

    [Header("Enemy Spawner")]
    public Text waveCounterText;
    public Text waveTimerText;
    public Text enemyCounterText;

    [Header("Player Health")]
    public Slider healthBar;
    public Text curHealthText;
    public Text maxHealthText;

    [Header("Inventory Manager")]
    public Text curAmmoText;
    public Text maxAmmoText;
    public Slider ammoBar;
    public Image arm1;
    public Image arm2;

    void Start()
    {
        InitializeReferences();
    }

    void Update()
    {
        UpdateEnemySpawnerUI();
        UpdatePlayerHealthUI();
        UpdateWeaponUI();
    }

    void InitializeReferences()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
        playerHealth = FindObjectOfType<HealthManager>();
        inventoryManager = FindObjectOfType<InventoryManager>();

        if (enemySpawner == null)
            Debug.Log("EnemySpawner not found in the scene.");

        if (playerHealth == null)
            Debug.Log("HealthManager not found in the scene.");

        if (inventoryManager == null)
            Debug.Log("WeaponSwap not found in the scene.");
    }

    void UpdateEnemySpawnerUI()
    {
        if (enemySpawner != null)
        {
            waveCounterText.text = Mathf.Max(0, enemySpawner.curWaveNumber).ToString();
            waveTimerText.text = Mathf.Max(0, enemySpawner.curWaveTimer).ToString("F1");
            enemyCounterText.text = Mathf.Max(0, enemySpawner.curEnemyCount).ToString();
        }
    }

    void UpdatePlayerHealthUI()
    {
        if (playerHealth != null)
        {
            float healthValue = Mathf.Clamp(playerHealth.health, 0f, playerHealth.maxHealth);
            healthBar.value = healthValue;
            curHealthText.text = healthValue.ToString("F0");
            maxHealthText.text = "/ " + playerHealth.maxHealth.ToString("F0");
        }
    }

    void UpdateWeaponUI()
    {
        if (inventoryManager != null)
        {
            curAmmoText.text = inventoryManager.getCurrentAmmo().ToString();
            maxAmmoText.text = "/  " + inventoryManager.getMaxAmmo().ToString();
            ammoBar.maxValue = inventoryManager.getMaxAmmo();
            ammoBar.value = inventoryManager.getCurrentAmmo();

            Sprite arm1 = inventoryManager.getArm1Sprite();
            Sprite arm2 = inventoryManager.getArm1Sprite();
        }
    }
}
