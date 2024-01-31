using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField]
    protected HealthValue health;
    //[SerializeField]
    //protected HealthValue maxHealth;
    [HideInInspector]
    protected HealthValue healthChange;


#if UNITY_EDITOR
    [Header("Debugging")]
    [SerializeField, ReadOnly] private float dbg_healthValue;
#endif

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

#if UNITY_EDITOR
    private void Update()
    {
        dbg_healthValue = health.value;
    }
#endif

}
