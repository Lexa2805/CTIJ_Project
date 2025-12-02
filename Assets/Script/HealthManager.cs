using UnityEngine;
using UnityEngine.UI; // Required for UI

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
        // Reset health to full at start
        p1CurrentHealth = p1MaxHealth;
        p2CurrentHealth = p2MaxHealth;
    }

    // Call this function when Player 1 gets hit
    public void TakeDamageP1(float damage)
    {
        p1CurrentHealth -= damage;
        // Ensure health doesn't go below 0
        if (p1CurrentHealth < 0) p1CurrentHealth = 0;

        // Update the UI Bar (Amount must be between 0 and 1)
        p1HealthBar.fillAmount = p1CurrentHealth / p1MaxHealth;
    }

    // Call this function when Player 2 gets hit
    public void TakeDamageP2(float damage)
    {
        p2CurrentHealth -= damage;
        if (p2CurrentHealth < 0) p2CurrentHealth = 0;

        p2HealthBar.fillAmount = p2CurrentHealth / p2MaxHealth;
    }

    // DEBUG: Press buttons to test damage
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U)) TakeDamageP1(10); // Hurt P1
        if (Input.GetKeyDown(KeyCode.I)) TakeDamageP2(10); // Hurt P2
    }
}