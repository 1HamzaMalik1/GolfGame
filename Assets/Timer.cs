using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static Timer Instance;
    public Text timerText;
    public GameObject gameOverPanel;

    private float timeRemaining = 240f;
    private bool isTimerRunning = true;

    public bool isStoped = false;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (isTimerRunning)
        {
            if (timeRemaining > 0)
            {
                if (isStoped == false)
                {
                    timeRemaining -= Time.deltaTime;
                }

                if (timeRemaining > 0)
                {
                    UpdateTimerUI(timeRemaining);
                }
            }
            else
            {
                isTimerRunning = false;
                timeRemaining = 0;
                TimerEnded();
            }
        }
    }

    void UpdateTimerUI(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        timerText.text = "TIME : " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void TimerEnded()
    {
        Debug.Log("Time's up! Level Failed.");
        gameOverPanel.SetActive(true);
        // Optionally freeze game
        Time.timeScale = 0f;
    }

    public void ResetBallPosition()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
