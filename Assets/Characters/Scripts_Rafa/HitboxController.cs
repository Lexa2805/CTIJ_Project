using UnityEngine;

public class HitboxController : MonoBehaviour
{
    public float damageAmount = 10f;
    public GameObject owner;

    private bool hasHit = false;

    void OnEnable()
    {
        hasHit = false;
        Debug.Log("🟢 Hitbox ACTIVAT: " + gameObject.name);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("🟡 Coliziune detectată cu: " + other.gameObject.name);

        if (hasHit) return;

       
        if (other.gameObject == owner)
        {
            Debug.Log("--- Ignor (Owner)");
            return;
        }

       
        HealthController targetHealth = other.GetComponentInParent<HealthController>();

        if (targetHealth != null)
        {
            Debug.Log("🔴 INAMIC GĂSIT! ");
            targetHealth.TakeDamage(damageAmount);
            hasHit = true;
        }
        else
        {
            Debug.Log("--- Obiectul lovit NU are HealthController în Parent.");
        }
    }
}
