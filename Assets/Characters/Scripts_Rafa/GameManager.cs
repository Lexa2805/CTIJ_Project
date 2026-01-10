using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [Header("UI Reference")]
    public Text winnerText;

    public HealthController player1Health;
    public HealthController player2Health;

    private bool isGameOver = false;

    public void EndGame(string deadCharacterName)
    {
        if (isGameOver) return;
        isGameOver = true;

        StartCoroutine(EndGameSequence(deadCharacterName));
    }

    IEnumerator EndGameSequence(string deadCharacterName)
    {
        yield return new WaitForSeconds(3.0f);

        winnerText.gameObject.SetActive(true);
      

        if (deadCharacterName == "Arissa")
        {
            winnerText.text = "Medea Wins!";
        }
        else
        {
            winnerText.text = "Arissa Wins!";
        }

        Time.timeScale = 0;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void EndGameByTime()
    {
        if (isGameOver) return;
        isGameOver = true;

        winnerText.gameObject.SetActive(true);

        float p1HP = player1Health.GetCurrentHealth();
        float p2HP = player2Health.GetCurrentHealth();

        if (p1HP > p2HP)
        {
            winnerText.text = "Arissa Wins!";
        }
        else if (p2HP > p1HP)
        {
            winnerText.text = "Medea Wins!";
        }
        else
        {
            winnerText.text = "DRAW!";
        }

        Time.timeScale = 0f;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }


}