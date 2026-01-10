using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    [Header("Timer Settings")]
    public float startTime = 10f;
    public float timeRemaining;
    public bool timerIsRunning;

    [Header("UI")]
    public TextMeshProUGUI timeText;

    [Header("References")]
    public GameManager gameManager;
    public HealthManager healthManager;

    private void Start()
    {
        ResetTimer();
        StartTimer();
    }

    private void Update()
    {
        if (!timerIsRunning) return;

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            DisplayTime(timeRemaining);
        }
        else
        {
            timeRemaining = 0;
            timerIsRunning = false;
            DisplayTime(timeRemaining);
            TimerFinished();
        }
    }

    private void TimerFinished()
    {
        Debug.Log("Time has run out!");

        if (gameManager != null)
        {
            gameManager.EndGameByTime();
        }
    }


    public void StartTimer()
    {
        timerIsRunning = true;
    }

    public void ResetTimer()
    {
        timeRemaining = startTime;
        DisplayTime(timeRemaining);
    }

    private void DisplayTime(float timeToDisplay)
    {
        int seconds = Mathf.CeilToInt(timeToDisplay);
        timeText.text = seconds.ToString();
    }
}
