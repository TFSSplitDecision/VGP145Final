using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-1)]
public class LevelTransitionScript : MonoBehaviour
{
    static LevelTransitionScript instance = null;
    public static LevelTransitionScript Instance => instance;
 
        private void Start()
        {
            if (instance)
            {
                Destroy(gameObject);
                return;
            }
            instance = this;
            DontDestroyOnLoad(this);
        }
    

    public void ChangeScene(int sceneindex)
    {
        SceneManager.LoadScene(sceneindex);

    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeScene(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeScene(1);
        }
    }

    public void MoveToMainMenu()
    {
        ChangeScene(0);
    }

    public void MoveToMainGame()
    {
        ChangeScene(1);
    }
}
