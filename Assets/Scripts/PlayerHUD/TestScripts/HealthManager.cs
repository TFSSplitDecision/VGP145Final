using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField]
    protected HealthValue health;
    //[SerializeField]
    //protected HealthValue maxHealth;
    [HideInInspector]
    protected HealthValue healthChange;

    public void RestoreHealth()
    {
        health.value = 100;
    }

    public void GainHealth(float healthChange)
    {
        health.value += healthChange;

        if (health.value > 100) health.value = 100;
    }

    public void LoseHealth(float healthChange)
    {
        health.value -= healthChange;

        if (health.value < 0) health.value = 0;
    }

    public float GetHealth()
    {
        return health.value;
    }
}