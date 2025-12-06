using UnityEngine;

public class UniversalCombat : MonoBehaviour
{
    [Header("Taste Atac")]
    public KeyCode punchKey = KeyCode.E;
    public KeyCode kickKey = KeyCode.R;
    public KeyCode blockKey = KeyCode.F;
    public KeyCode shootKey = KeyCode.Q;

    [Header("Referințe")]
    public Animator animator;

    [Header("Hitbox-uri / Proiectile")]
    public GameObject punchHitbox;
    public GameObject kickHitbox;
    public GameObject bulletPrefab;
    public Transform shootPoint;

    void Start()
    {
        if (punchHitbox != null) punchHitbox.SetActive(false);
        if (kickHitbox != null) kickHitbox.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(punchKey))
            animator.SetBool("IsPunching", true);
        if (Input.GetKeyUp(punchKey))
            animator.SetBool("IsPunching", false);

        if (Input.GetKeyDown(kickKey))
            animator.SetBool("IsKicking", true);
        if (Input.GetKeyUp(kickKey))
            animator.SetBool("IsKicking", false);

        animator.SetBool("IsGuarding", Input.GetKey(blockKey));

        if (Input.GetKeyDown(shootKey))
            animator.SetBool("IsShooting", true);
        if (Input.GetKeyUp(shootKey))
            animator.SetBool("IsShooting", false);
    }

    public void EnablePunch()
    {
        if (punchHitbox != null) punchHitbox.SetActive(true);
    }

    public void DisablePunch()
    {
        if (punchHitbox != null) punchHitbox.SetActive(false);
    }

    public void EnableKick()
    {
        if (kickHitbox != null) kickHitbox.SetActive(true);
    }

    public void DisableKick()
    {
        if (kickHitbox != null) kickHitbox.SetActive(false);
    }

    public void Shoot()
    {
        if (bulletPrefab != null && shootPoint != null)
            Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
    }
}
