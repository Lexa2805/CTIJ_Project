using UnityEngine;
using TMPro;

public class HealthController : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    public Animator characterAnimator;

    [Header("UI")]
    public TMP_Text hpText;

    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        isDead = false;
        UpdateHPText();
    }

    public void TakeDamage(float damage)
    {
        if (isDead) return;
        if (characterAnimator.GetBool("IsGuarding"))
        {
            Debug.Log(" blocked attack!");

           
            return;        
            // damage = damage / 2;
        }

        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;

        Debug.Log(gameObject.name + " HP: " + currentHealth);

        UpdateHPText();

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            characterAnimator.SetTrigger("Hit");
        }
    }

    void UpdateHPText()
    {
        if (hpText != null)
        {
            hpText.text = gameObject.name + " HP: " + Mathf.CeilToInt(currentHealth);
        }
    }

    void Die()
    {
        if (isDead) return;
        isDead = true;

        characterAnimator.SetTrigger("Death");

        
        GameManager gm = FindObjectOfType<GameManager>();
        if (gm != null)
        {
            gm.EndGame(gameObject.name);
        }
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }
}
