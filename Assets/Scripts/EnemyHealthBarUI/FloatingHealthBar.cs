using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Camera camera;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;

    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        transform.parent.rotation = camera.transform.rotation;
        transform.position = target.position + offset;
    }
    //add "[serializeField] FloatingHealthBar healthbar;" to enemy script
    //add "healthBar = GetComponentInChildren<FloatingHealthBar>();" to enemy script void awake
    //add "healthBar.UpdateHealthBar(health, maxHealth);" to enemy script TakeDamage(or similar function)
}
