using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public float startTime;

    private float elapsedTime;
    private int score;

    void Start()
    {
        elapsedTime = startTime;
        score = 0;
    }

    void Update()
    {
        elapsedTime -= Time.deltaTime;
        UpdateTimerDisplay();

        if (elapsedTime <= 0)
        {
            // Game over logic, like player death or level completion
            // Resets the timer & score
            ResetTimer();
        }
    
        //Increase score every second survived
        timer.IncreaseScore(Time.deltaTime);
    
    }

    void UpdateTimerDisplay()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    public void IncreaseScore(float amount)
    {
        score += Mathf.RoundToInt(amount);
        // Update score display here
    }

    void ResetTimer()
    {
        elapsedTime = startTime;
        score = 0;
    }
}
