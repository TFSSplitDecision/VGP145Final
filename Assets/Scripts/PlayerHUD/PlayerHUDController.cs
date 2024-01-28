using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUDController : MonoBehaviour
{
    private EnemySpawner enemySpawner;
    private PlayerHealth playerHealth; // Pending
    private WeaponSwap weaponSwap; // Pending

    [Header("Enemy Spawner")]
    public Text WaveCounter;
    public Text WaveTimer;
    public Text EnemyCounter;

    [Header("Player Health")] // Pending
    public Text CurHealthText;
    public Slider HealthBar;

    [Header("Weapon Swap")] // Pending
    public Text CurAmmoText;
    public Text MaxAmmoText;
    public Slider AmmoBar;

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
        playerHealth = FindObjectOfType<PlayerHealth>();
        weaponSwap = FindObjectOfType<WeaponSwap>();

        if (enemySpawner == null)
            Debug.LogError("EnemySpawner not found in the scene.");

        if (playerHealth == null)
            Debug.LogError("PlayerHealth not found in the scene.");

        if (weaponSwap == null)
            Debug.LogError("WeaponSwap not found in the scene.");
    }

    void UpdateEnemySpawnerUI()
    {
        if (enemySpawner != null)
        {
            WaveCounter.text = Mathf.Max(0, enemySpawner.curWaveNumber).ToString();
            WaveTimer.text = Mathf.Max(0, enemySpawner.curWaveTimer).ToString();
            EnemyCounter.text = Mathf.Max(0, enemySpawner.curEnemyCount).ToString();
        }
    }

    void UpdatePlayerHealthUI()
    {
        if (playerHealth != null)
        {
            playerHealth.currentHealth = Mathf.Clamp(playerHealth.currentHealth, 0, 100);
            HealthBar.value = playerHealth.currentHealth;
            CurHealthText.text = playerHealth.currentHealth.ToString();
        }
    }

    void UpdateWeaponSwapUI()
    {
        if (weaponSwap != null)
        {
            (int curAmmo, int maxAmmo) = weaponSwap.GetActiveWeaponAmmo();

            CurAmmoText.text = curAmmo.ToString();
            MaxAmmoText.text = "/  " + maxAmmo.ToString();
            AmmoBar.maxValue = maxAmmo;
            AmmoBar.value = curAmmo;
        }
    }
}
