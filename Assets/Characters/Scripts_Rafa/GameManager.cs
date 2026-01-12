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

   
    void Update()
    {

        // M - Restart 
        if (Input.GetKeyDown(KeyCode.M))
        {
            GoToMainMenu();
        }

        // N - Quit Game
        if (Input.GetKeyDown(KeyCode.N))
        {
            QuitGame();
        }
    }

    public void EndGame(string deadCharacterName)
    {
        if (isGameOver) return;
        isGameOver = true;

        StartCoroutine(EndGameSequence(deadCharacterName));
    }

    IEnumerator EndGameSequence(string deadCharacterName)
    {
        yield return new WaitForSeconds(3.0f);

        if (winnerText != null)
        {
            winnerText.gameObject.SetActive(true);

            string message = "";
            if (deadCharacterName == "Arissa")
            {
                message = "Medea Wins!";
            }
            else
            {
                message = "Arissa Wins!";
            }

          
            message += "\n\nPress 'M' for Main Menu\nPress 'N' to Quit";
            winnerText.text = message;
        }

        Time.timeScale = 0; 

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void EndGameByTime()
    {
        if (isGameOver) return;
        isGameOver = true;

        if (winnerText != null)
        {
            winnerText.gameObject.SetActive(true);

            float p1HP = player1Health.GetCurrentHealth();
            float p2HP = player2Health.GetCurrentHealth();

            string message = "";

            if (p1HP > p2HP)
                message = "Arissa Wins!";
            else if (p2HP > p1HP)
                message = "Medea Wins!";
            else
                message = "DRAW!";

            
            message += "\n\nPress 'M' for Menu\nPress 'N' to Quit";
            winnerText.text = message;
        }

        Time.timeScale = 0f;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    

    void GoToMainMenu()
    {
        
        Time.timeScale = 1f;

        
       
        SceneManager.LoadScene("SampleScene");
    }

    void QuitGame()
    {
        Debug.Log("QUIT GAME!");
        Application.Quit();

        
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
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
            Time.timeScale = 1f; 

           
            GameObject p1 = GameObject.Find("Arissa");
            if (p1) player1Health = p1.GetComponent<HealthController>();

            GameObject p2 = GameObject.Find("Medea");
            if (p2) player2Health = p2.GetComponent<HealthController>();

            
            GameObject wt = GameObject.Find("Winner_Text");
            if (wt)
            {
                winnerText = wt.GetComponent<Text>();
                winnerText.gameObject.SetActive(false);
            }
            else
            {
                Debug.LogError("Winner_Text lipseste din scena Neon City!");
            }

            Debug.Log("GameManager: Scena Neon City initializata.");
        }
    }
}