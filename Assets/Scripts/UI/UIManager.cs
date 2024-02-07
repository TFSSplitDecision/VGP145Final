using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{
    //Do we even need to find class instead of just Canvas Object?
    //public MainMenuController mm;
    [HideInInspector]
    public Canvas pm;
    public Canvas gm;

    //public Canvas prefabpm;
    //public Canvas prefabgm;

    public override void Awake()
    {
        base.Awake();
    }
    void OnEnable()
    {
        //Subscribing an method to an event(SceneManager.sceneLoaded).
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnDisable()
    {
        //Unsubscribe when UIManager is somehow disabled.
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    void Start()
    {
        //try
        //{
        //    Debug.Log(pm.gameObject.name + gm.gameObject.name);
        //}
        //catch (Exception e)
        //{
        //    //String based on exception type apparently.
        //    Debug.Log(e.Message);
        //}
    }

    //This is probably an anti-design pattern.
    //Don't know if LoadSceneMode matters but it's apparently a required parameter.
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene != null)
        {
            if (scene.name == "GameOverScene")
            {
                //Try to get GameOverMenuController.
                gm = FindObjectOfType<Canvas>();
                //If you can't.
                if (gm == null)
                {
                    //Instantiate one.
                    //Apparently this is unscalable but good enough for this project size.
                    Resources.Load<GameObject>("Assets/Prefabs/MenuPrefabs/GameOverMenu");
                    //if (gameOverMenuPrefab != null)
                    //{
                    //    GameObject gameOverMenuObject = Instantiate(gameOverMenuPrefab);
                    //    gm = gameOverMenuObject.GetComponent<GameOverMenuController>();
                    //}
                    //else
                    //{
                    //    Debug.LogError("GameOverMenuPrefab is missing.");
                    //}
                }
            }
            if (scene.name == "MainMenuScene")
            {

            }
        }
        else
        {
            Debug.Log("Missing Scene Info");
        }
    }
}
