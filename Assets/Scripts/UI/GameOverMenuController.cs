using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenuController : MonoBehaviour
{
    public UnityEngine.UI.Image winScreen;
    public UnityEngine.UI.Image loseScreen;
    private Button[] buttons = new Button[2];

    void Start()
    {
        //Get Return Button then Exit Button from Scene Hierarchy.
        buttons = GetComponentsInChildren<Button>();
        //How the fuck do I use exceptions
        Debug.Log(buttons[0].name + " " + buttons[1].name);

        //Gotta figure out sceneIndex.
        //buttons[0].onClick.AddListener(ChangeScene(sceneIndex));
        buttons[1].onClick.AddListener(QuitGame);

        //Assuming there's a Win Screen and Lose Screen to display.
        ////if (GameManager.winState)
        //    winScreen.gameObject.SetActive(true);
        //    winAudio.gameObject.SetActive(true);
        ////else if (!GameManager.winState)
        //    loseScreen.gameObject.SetActive(true);
        //    loseAudio.gameObject.SetActive(true);


        //If any stats to display, it'd be here. (set scoreDisplay to score etc.)
        //scoreDisplay = GameManager.Instance.scoreText.toString
    }

    //Could just load the Main Menu without taking an argument but whatever?
    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    //Maybe something the GameManager should have instead.
    private void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
