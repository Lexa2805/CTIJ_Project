using UnityEngine;
using UnityEngine.UI; 

public class HealthManager : MonoBehaviour
{
    [Header("Player 1 Settings")]
    public Image p1HealthBar;
    public float p1MaxHealth = 100f;
    public float p1CurrentHealth;

    [Header("Player 2 Settings")]
    public Image p2HealthBar;
    public float p2MaxHealth = 100f;
    public float p2CurrentHealth;

    void Start()
    {
       
        p1CurrentHealth = p1MaxHealth;
        p2CurrentHealth = p2MaxHealth;
    }

    
    public void TakeDamageP1(float damage)
    {
        p1CurrentHealth -= damage;
       
        if (p1CurrentHealth < 0) p1CurrentHealth = 0;

        
        p1HealthBar.fillAmount = p1CurrentHealth / p1MaxHealth;
    }

   
    public void TakeDamageP2(float damage)
    {
        p2CurrentHealth -= damage;
        if (p2CurrentHealth < 0) p2CurrentHealth = 0;

        p2HealthBar.fillAmount = p2CurrentHealth / p2MaxHealth;
    }

    public float GetP1Health()
    {
        return p1CurrentHealth;
    }

    public float GetP2Health()
    {
        return p2CurrentHealth;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U)) TakeDamageP1(10); 
        if (Input.GetKeyDown(KeyCode.I)) TakeDamageP2(10); 
    }
}