using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Singleton pattern for score manager

    public static ScoreManager instance;

    private int score;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Public function to return the current score when called
    public int GetScore()
    {
        return score;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
