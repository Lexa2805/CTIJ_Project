using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public float startTime = 99f;
    public TMP_Text timerText;

    private float timeRemaining;
    private bool timeUp = false;

    void Start()
    {
        timeRemaining = startTime;
        UpdateTimerUI();
    }

    void Update()
    {
        if (timeUp) return;

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0f)
        {
            timeRemaining = 0f;
            timeUp = true;

            Debug.Log("TIME UP");

            GameManager.Instance.EndGameByTime();
        }

        UpdateTimerUI();
    }

    void UpdateTimerUI()
    {
        if (timerText != null)
        {
            timerText.text = Mathf.CeilToInt(timeRemaining).ToString();
        }
    }
}
