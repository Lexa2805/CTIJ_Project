using UnityEngine;

public class MedeaAttack : MonoBehaviour
{
    [Header("Attack Keys (Medea)")]
    public KeyCode punchKey = KeyCode.Keypad1;
    public KeyCode kickKey = KeyCode.Keypad2;
    public KeyCode jumpKey = KeyCode.Keypad0;
    public KeyCode guardKey = KeyCode.L;

    [Header("References")]
    public Animator animator;

    [Header("Hitboxes")]
    public GameObject punchHitbox;
    public GameObject kickHitbox;

    void Start()
    {
        if (punchHitbox) punchHitbox.SetActive(false);
        if (kickHitbox) kickHitbox.SetActive(false);
    }

    void Update()
    {
        HandlePunch();
        HandleKick();
        HandleJump();
        animator.SetBool("IsGuarding", Input.GetKey(guardKey));
    }

    private void HandlePunch()
    {
        if (Input.GetKeyDown(punchKey))
            animator.SetTrigger("Punch");
    }

    private void HandleKick()
    {
        if (Input.GetKeyDown(kickKey))
            animator.SetTrigger("Kick");
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(jumpKey))
            animator.SetTrigger("Jump");
    }

    // Animation Events
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
}
