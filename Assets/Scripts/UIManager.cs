using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public int currentLevel;
    public GameObject levelCompletePanel;
    public GameObject gameOverPanel;
    public GameObject pausePanel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ResetPanels();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        ResetPanels();
    }

    public void NextLevel()
    {
        if (currentLevel == 1)
        {
            SceneManager.LoadScene(1);
            currentLevel += 1;
        }
        else
        {
            SceneManager.LoadScene(0);
        }

        ResetPanels();
    }

    public void ResetPanels()
    {
        
        levelCompletePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        pausePanel.SetActive(false);
    }
    
}
