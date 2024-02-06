using TMPro;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public TextMeshProUGUI playerHealthText;
    public TextMeshProUGUI enemyHealthText;

    [SerializeField]
    protected HealthValue playerHealth;
    [SerializeField]
    protected HealthValue enemyHealth;

    void Update()
    {
        if (playerHealthText)
        {
            UpdatePlayerHealthText(playerHealth.value);
        }

        if (enemyHealthText)
        {
            UpdateEnemyHealthText(enemyHealth.value);
        }
    }

    void UpdatePlayerHealthText(float value)
    {
        playerHealthText.text = "Player Health: " + value.ToString() + "%";
    }

    void UpdateEnemyHealthText(float value)
    {
        enemyHealthText.text = "Enemy Health: " + value.ToString() + "%";
    }
}
