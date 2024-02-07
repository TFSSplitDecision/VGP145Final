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

        buttons[0].onClick.AddListener(Resume);
        //Figure out Scene Index.
        //buttons[1].onClick.AddListener(ChangeScene(sceneIndex));
    }
    public void Pause()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
        Debug.Log(Time.timeScale);
    }

    private void Resume()
    {
        Time.timeScale = 1;
        Debug.Log(Time.timeScale);
        gameObject.SetActive(false);
    }

    private void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}