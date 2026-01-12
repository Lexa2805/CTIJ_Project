using UnityEngine;

public class HitboxController : MonoBehaviour
{
    public float damageAmount = 10f;
    public GameObject owner;

    private bool hasHit = false;

    void OnEnable()
    {
        hasHit = false;
        Debug.Log("🟢 Hitbox activated: " + gameObject.name);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("🟡 Collision detected " + other.gameObject.name);

        if (hasHit) return;

       
        if (other.gameObject == owner)
        {
            Debug.Log("Ignore (Owner)");
            return;
        }

       
        HealthController targetHealth = other.GetComponentInParent<HealthController>();

        if (targetHealth != null)
        {
            Debug.Log("🔴 Enemy found ");
            targetHealth.TakeDamage(damageAmount);
            hasHit = true;
        }
        else
        {
            Debug.Log("Obiectul lovit nu are HealthController ");
        }
    }
}
