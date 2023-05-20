using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject MainMenuPanel;
    public GameObject OptionsPanel;
    public GameObject PauseMenuPanel;
    public GameObject IconPanel;

    private void Start()
    {
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("UI"));
        GameObject.FindGameObjectWithTag("Pause Menu UI").SetActive(false);
    }

    //Main Menu
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        MainMenuPanel.SetActive(false);
        IconPanel.SetActive(true);
        GameManager.instance.UpdateGameState(GameManager.GameState.Play);
    }

    public void OpenOptionsPanel()
    {
        OptionsPanel.SetActive(true);
        ClosePauseMenu();
    }

    public void CloseOptionsPanel()
    {
        OptionsPanel.SetActive(false);
    }

    public void Exit()
    {
        GameManager.instance.UpdateGameState(GameManager.GameState.Quit);
        Application.Quit();
    }

//Pause Menu

    public void OpenPauseMenu()
    {
        //Time.timeScale = 0f;
        CloseOptionsPanel();
        PauseMenuPanel.SetActive(true);
    }

    public void ClosePauseMenu()
    {
        //Time.timeScale = 1f;
        PauseMenuPanel.SetActive(false);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Main Menu");
        MainMenuPanel.SetActive(true);
    }
}
