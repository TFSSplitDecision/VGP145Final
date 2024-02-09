using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{
    //Main Menu, HUD, Pause Menu, Game Over Menu
    public Canvas prefabmm;
    public Canvas prefabhud;
    public Canvas prefabpm;
    public Canvas prefabgm;

    Canvas mm;
    Canvas hud;
    Canvas pm;
    Canvas gm;

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

    //Don't know if LoadSceneMode matters but it's apparently a required parameter.
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene Loaded");
        if (scene != null)
        {
            //Don't know scenenames.
            if (scene.name == "MainMenuScene")
            {
                mm = FindObjectOfType<Canvas>();
                if (!mm)
                    Instantiate(prefabmm);
            }
            if (scene.name == "GameScene")
            {
                //UIManager handles enabling and disabling.
                pm = FindObjectOfType<Canvas>();
                if (!pm)
                    pm = Instantiate(prefabpm);
                pm.gameObject.SetActive(false);

                hud = FindObjectOfType<Canvas>();
                if (!hud)
                    hud = Instantiate(prefabhud);
            }
            else if (scene.name == "GameOverScene")
            {
                gm = FindObjectOfType<Canvas>();
                if (!gm)
                {
                    Instantiate(prefabgm);
                }
            }
        }
        else
        {
            Debug.Log("Missing Scene Info");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pm)
        {
            pm.gameObject.SetActive(true);
        }
    }
}