using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuPanel, SettingsPanel, CreditsPanel;

    // Start is called before the first frame update
    void Start()
    {
        MainMenuPanel.SetActive(true);
        SettingsPanel.SetActive(false);
        CreditsPanel.SetActive(false);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("LevelDesignTestScene1");
    }
    public void OpenSettings()
    {
        MainMenuPanel.SetActive(false);
        SettingsPanel.SetActive(true);
        CreditsPanel.SetActive(false);
    }
    public void ClosePanel ()
    {
        MainMenuPanel.SetActive(true);
        SettingsPanel.SetActive(false);
        CreditsPanel.SetActive(false);
    }
    public void OpenCredits()
    {
        MainMenuPanel.SetActive(false);
        SettingsPanel.SetActive(false);
        CreditsPanel.SetActive(true);
    }
    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
