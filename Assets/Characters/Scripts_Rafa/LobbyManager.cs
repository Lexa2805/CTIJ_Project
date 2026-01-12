using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{
    [Header("Player 1 UI")]
    public GameObject p1JoinPrompt; //  "Press X to Join"
    public GameObject p1ReadyText;  

    [Header("Player 2 UI")]
    public GameObject p2JoinPrompt; //  "Press K to Join"
    public GameObject p2ReadyText;  

    [Header("Global UI")]
    public GameObject startFightButton; 

    
    private bool isP1Ready = false;
    private bool isP2Ready = false;

    void Start()
    {
        
        p1ReadyText.SetActive(false);
        p2ReadyText.SetActive(false);
        startFightButton.SetActive(false);

        
        p1JoinPrompt.SetActive(true);
        p2JoinPrompt.SetActive(true);
    }

    void Update()
    {
       
       
        if (Input.GetKeyDown(KeyCode.X) && isP1Ready == false)
        {
            isP1Ready = true;
            p1JoinPrompt.SetActive(false); 
            p1ReadyText.SetActive(true);   
            CheckIfBothReady();            
        }

        if (Input.GetKeyDown(KeyCode.K) && isP2Ready == false)
        {
            isP2Ready = true;
            p2JoinPrompt.SetActive(false); 
            p2ReadyText.SetActive(true);   
            CheckIfBothReady();
        }
    }

    private void CheckIfBothReady()
    {
        if (isP1Ready && isP2Ready)
        {
           
            startFightButton.SetActive(true);
        }
    }

    
    public void StartTheFight()
    {
        SceneManager.LoadScene("Neon City");
    }
}