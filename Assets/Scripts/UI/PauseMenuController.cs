using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//GameObject stored in GameOverScene for now, should be compatible with any Game Scene.
//Menu GameObject would be inactive by default, needs external dereference to toggle it.
public class PauseMenuController : MonoBehaviour
{
    private Button[] buttons = new Button[2];

    void Start()
    {
        buttons = GetComponentsInChildren<Button>();
        Debug.Log(buttons[0].name + " " + buttons[1].name);

        //These buttons aren't clickable for some reason.
        buttons[0].onClick.AddListener(Resume);
        buttons[1].onClick.AddListener(ChangeScene);
    }

    private void OnEnable()
    {
        //This feels horrible but it's more intuitive and reusable.
        Pause();
    }

    private void Pause()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
        Debug.Log(Time.timeScale);
    }

    private void Resume()
    {
        Debug.Log("Resume?");
        Time.timeScale = 1;
        Debug.Log(Time.timeScale);
        gameObject.SetActive(false);
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene("MainMenuTestScene");
    }
}