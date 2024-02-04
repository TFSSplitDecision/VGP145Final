using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    protected HealthValue playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth.value = 100;
    }
}
