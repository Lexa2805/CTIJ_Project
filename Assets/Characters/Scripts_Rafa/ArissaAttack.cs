using UnityEngine;

public class ArissaAttack : MonoBehaviour
{
    [Header("Attack Keys (Arissa)")]
    public KeyCode punchKey = KeyCode.E;
    public KeyCode kickKey = KeyCode.R;
    public KeyCode blockKey = KeyCode.F;
    public KeyCode shootKey = KeyCode.Q;
    public KeyCode jumpKey = KeyCode.Space;

    [Header("References")]
    public Animator animator;

    [Header("Hitboxes & Projectile")]
    public GameObject punchHitbox;
    public GameObject kickHitbox;
    public GameObject bulletPrefab;
    public Transform shootPoint;

    void Start()
    {
        if (punchHitbox) punchHitbox.SetActive(false);
        if (kickHitbox) kickHitbox.SetActive(false);
    }

    void Update()
    {
     
        animator.SetBool("IsPunching", Input.GetKey(punchKey));

     
        animator.SetBool("IsKicking", Input.GetKey(kickKey));

        animator.SetBool("IsGuarding", Input.GetKey(blockKey));

   
        animator.SetBool("IsShooting", Input.GetKey(shootKey));

        if (Input.GetKeyDown(jumpKey))
            animator.SetTrigger("IsJumping");
    }

 
    public void EnablePunchHitbox()
    {
        if (punchHitbox) punchHitbox.SetActive(true);
    }

    public void DisablePunchHitbox()
    {
        if (punchHitbox) punchHitbox.SetActive(false);
    }

    public void EnableKickHitbox()
    {
        if (kickHitbox) kickHitbox.SetActive(true);
    }

    public void DisableKickHitbox()
    {
        if (kickHitbox) kickHitbox.SetActive(false);
    }

    public void Shoot()
    {
        if (bulletPrefab && shootPoint)
            Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
    }
}
