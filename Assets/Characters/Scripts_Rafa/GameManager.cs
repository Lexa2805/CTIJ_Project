using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

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

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Neon City")
        {
            isGameOver = false;

            player1Health = GameObject.Find("Arissa")
                .GetComponent<HealthController>();

            player2Health = GameObject.Find("Medea")
                .GetComponent<HealthController>();

            GameObject wt = GameObject.Find("Winner_Text");
            if (wt == null)
            {
                Debug.LogError("Winner_Text not found");
                return;
            }
            winnerText = wt.GetComponent<Text>();


            if (winnerText == null || player1Health == null || player2Health == null)
            {
                Debug.LogError("GameManager: Missing references in Neon City");
                return;
            }

            winnerText.gameObject.SetActive(false);
            Time.timeScale = 1f;

            Debug.Log("GameManager linked to Neon City");
        }
    }



}