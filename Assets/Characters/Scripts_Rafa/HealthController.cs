using UnityEngine;

public class HealthController : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    public Animator characterAnimator;

    private bool isDead = false; 

    void Start()
    {
        currentHealth = maxHealth;
        isDead = false;
    }

    public void TakeDamage(float damage)
    {
        if (isDead) return; 

        currentHealth -= damage;
         Debug.Log(gameObject.name + " HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die(); 
        }
        else
        {
            characterAnimator.SetTrigger("Hit"); 
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
}