using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwap : MonoBehaviour
{
    public GameObject weapon1;
    public GameObject weapon2;
    public GameObject weapon3;
    public GameObject weapon4;

    [SerializeField] private int curAmmo3 = 0;
    [SerializeField] private int maxAmmo3 = 15;
    [SerializeField] private int curAmmo4 = 0;
    [SerializeField] private int maxAmmo4 = 25;

    private int currentAmmo;
    private int maxAmmo;

    void Start()
    {
        DeactivateAllWeapons();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ActivateWeapon(weapon1, 0, 0); // Pass 0 ammo for weapons 1 and 2
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ActivateWeapon(weapon2, 0, 0); // Pass 0 ammo for weapons 1 and 2
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ActivateWeapon(weapon3, curAmmo3, maxAmmo3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ActivateWeapon(weapon4, curAmmo4, maxAmmo4);
        }
    }

    void ActivateWeapon(GameObject weapon, int curAmmo, int maxAmmo)
    {
        DeactivateAllWeapons();
        weapon.SetActive(true);
        currentAmmo = curAmmo;
        this.maxAmmo = maxAmmo;
        Debug.Log("Activated: " + weapon.name + ", Current Ammo: " + currentAmmo + " / Max Ammo: " + this.maxAmmo);
    }

    void DeactivateAllWeapons()
    {
        weapon1.SetActive(false);
        weapon2.SetActive(false);
        weapon3.SetActive(false);
        weapon4.SetActive(false);
    }

    // Method to get active weapon details
    public (int, int) GetActiveWeaponAmmo()
    {
        return (currentAmmo, maxAmmo);
    }
}
