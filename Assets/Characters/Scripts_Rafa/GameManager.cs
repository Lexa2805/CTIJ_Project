using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [Header("UI Reference")]
    public Text winnerText;
   

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
}