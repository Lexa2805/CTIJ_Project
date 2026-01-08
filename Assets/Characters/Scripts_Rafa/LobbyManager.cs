using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{
    [Header("Player 1 UI")]
    public GameObject p1JoinPrompt; // Textul/Imaginea: "Press X to Join"
    public GameObject p1ReadyText;  // Textul: "READY"

    [Header("Player 2 UI")]
    public GameObject p2JoinPrompt; // Textul/Imaginea: "Press K to Join"
    public GameObject p2ReadyText;  // Textul: "READY"

    [Header("Global UI")]
    public GameObject startFightButton; // Butonul final de Start

    // Variabile de stare
    private bool isP1Ready = false;
    private bool isP2Ready = false;

    void Start()
    {
        // Resetăm starea la început
        p1ReadyText.SetActive(false);
        p2ReadyText.SetActive(false);
        startFightButton.SetActive(false);

        // Afișăm instrucțiunile de Join
        p1JoinPrompt.SetActive(true);
        p2JoinPrompt.SetActive(true);
    }

    void Update()
    {
        // --- LOGICA PLAYER 1 (Tasta X) ---
        // Verificăm dacă apasă X și dacă NU este deja ready
        if (Input.GetKeyDown(KeyCode.X) && isP1Ready == false)
        {
            isP1Ready = true;
            p1JoinPrompt.SetActive(false); // Ascundem instrucțiunea "Press X"
            p1ReadyText.SetActive(true);   // Afișăm "READY"
            CheckIfBothReady();            // Verificăm dacă putem începe
        }

        // --- LOGICA PLAYER 2 (Tasta K) ---
        // Verificăm dacă apasă K și dacă NU este deja ready
        if (Input.GetKeyDown(KeyCode.K) && isP2Ready == false)
        {
            isP2Ready = true;
            p2JoinPrompt.SetActive(false); // Ascundem instrucțiunea "Press K"
            p2ReadyText.SetActive(true);   // Afișăm "READY"
            CheckIfBothReady();
        }
    }

    private void CheckIfBothReady()
    {
        if (isP1Ready && isP2Ready)
        {
            // Când ambii sunt gata, apare butonul de start
            startFightButton.SetActive(true);
        }
    }

    // Această funcție rămâne publică pentru a fi apelată de Butonul "Start Fight"
    // SAU o poți apela cu o tastă (ex: Space) în Update, dacă preferi.
    public void StartTheFight()
    {
        SceneManager.LoadScene("Neon City");
    }
}