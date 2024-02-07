using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    protected HealthValue enemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        enemyHealth.value = 100;
    }
}
