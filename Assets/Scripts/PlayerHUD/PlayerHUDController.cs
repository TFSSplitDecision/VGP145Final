using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUDController : MonoBehaviour
{
    private EnemySpawner enemySpawner;
    private HealthManager playerHealth;
    private WeaponSwap weaponSwap; // Pending

    [Header("Enemy Spawner")]
    public Text waveCounterText;
    public Text waveTimerText;
    public Text enemyCounterText;

    [Header("Player Health")]
    public Slider healthBar;
    public Text curHealthText;

    [Header("Weapon Swap")] // Pending
    public Text curAmmoText;
    public Text maxAmmoText;
    public Slider ammoBar;

    void Start()
    {
        InitializeReferences();
    }

    void Update()
    {
        UpdateEnemySpawnerUI();
        UpdatePlayerHealthUI();
        UpdateWeaponSwapUI();
    }

    void InitializeReferences()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
        playerHealth = FindObjectOfType<HealthManager>();
        weaponSwap = FindObjectOfType<WeaponSwap>();

        if (enemySpawner == null)
            Debug.LogError("EnemySpawner not found in the scene.");

        if (playerHealth == null)
            Debug.LogError("HealthManager not found in the scene.");

        if (weaponSwap == null)
            Debug.LogError("WeaponSwap not found in the scene.");
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
            float healthValue = Mathf.Clamp(playerHealth.GetHealth(), 0f, 100f);

            healthBar.value = healthValue;
            curHealthText.text = healthValue.ToString("F0");
        }
    }

    void UpdateWeaponSwapUI()
    {
        if (weaponSwap != null)
        {
            (int curAmmo, int maxAmmo) = weaponSwap.GetActiveWeaponAmmo();

            curAmmoText.text = curAmmo.ToString();
            maxAmmoText.text = "/  " + maxAmmo.ToString();
            ammoBar.maxValue = maxAmmo;
            ammoBar.value = curAmmo;
        }
    }
}
