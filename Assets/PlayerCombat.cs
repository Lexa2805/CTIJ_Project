using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    // === ACEASTA ESTE LINIA NOUĂ CARE VA APĂREA ÎN INSPECTOR ===
    public GameObject punchHitbox;

    void Start()
    {
        // Ascundem hitbox-ul la începutul jocului
        if (punchHitbox != null)
        {
            punchHitbox.SetActive(false);
        }
    }

    void Update()
    {
        // PUMN (E)
        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetBool("IsPunching", true);
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            animator.SetBool("IsPunching", false);
        }

        // PICIOR (R)
        if (Input.GetKeyDown(KeyCode.R))
        {
            animator.SetBool("IsKicking", true);
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            animator.SetBool("IsKicking", false);
        }

        // APĂRARE (F)
        if (Input.GetKey(KeyCode.F))
        {
            animator.SetBool("IsGuarding", true);
        }
        else
        {
            animator.SetBool("IsGuarding", false);
        }

        // ARC (Click)
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("IsShooting", true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            animator.SetBool("IsShooting", false);
        }
    }

    // === FUNCȚII PENTRU ANIMATION EVENTS ===
    public void EnablePunch()
    {
        if (punchHitbox != null) punchHitbox.SetActive(true);
    }

    public void DisablePunch()
    {
        if (punchHitbox != null) punchHitbox.SetActive(false);
    }
}