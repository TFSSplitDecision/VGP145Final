using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestEnemyForFloatingHealthBar : MonoBehaviour
{
    [SerializeField] int health, maxHealth = 100;
    [SerializeField] FloatingHealthBar healthBar;

    private void Awake()
    {
        healthBar = GetComponentInChildren<FloatingHealthBar>();
    }
    
    private void Start()
    {
        health = maxHealth;
        StartCoroutine("decreaseHealth");
    }

    IEnumerator decreaseHealth()
    {
        yield return new WaitForSeconds(1);
        health -= 1;
        StartCoroutine("decreaseHealth");
        healthBar.UpdateHealthBar(health, maxHealth);
    }
}

