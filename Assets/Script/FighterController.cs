using UnityEngine;

public class FighterController : MonoBehaviour
{
    // VARIABLES
    public float moveSpeed = 5.0f;
    public float jumpForce = 500.0f; // Force to push player up

    private Animator animator;
    private Rigidbody rb; // We need this for physics movement

    // START
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>(); // Get the physics component
    }

    // UPDATE
    void Update()
    {
        // --- 1. MOVEMENT INPUT (Horizontal Only) ---
        // We only care about Left/Right (A/D). Ignore W/S for movement.
        float moveInput = Input.GetAxisRaw("Horizontal");

        // --- 2. APPLY MOVEMENT (PHYSICS) ---
        // We set the velocity directly. 
        // X = Movement, Y = Current Gravity (don't change it), Z = 0 (locked)
        rb.linearVelocity = new Vector3(moveInput * moveSpeed, rb.linearVelocity.y, 0);
        rb.AddForce(Vector3.down * 5000 * Time.deltaTime);
        // --- 3. ANIMATION & ROTATION ---
        if (Mathf.Abs(moveInput) > 0.1f)
        {
            animator.SetBool("isWalking", true);

            // ROTATION: Face Right if input > 0, Face Left if input < 0
            if (moveInput > 0)
                transform.rotation = Quaternion.Euler(0, 90, 0);
            else
                transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        // --- 4. COMBAT INPUTS ---

        // PUNCH (Press J)
        if (Input.GetKeyDown(KeyCode.J))
        {
            animator.SetTrigger("Punch");
        }

        // KICK (Press K)
        if (Input.GetKeyDown(KeyCode.K))
        {
            animator.SetTrigger("Kick");
        }

        // JUMP (Press Space)
        // Check if we are near the ground (velocity y is near 0) so we can't double jump forever
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.linearVelocity.y) < 0.01f)
        {
            animator.SetTrigger("Jump");
            // actually push the character up!
            rb.AddForce(Vector3.up * jumpForce);
        }

        // TEST HIT (Press H)
        if (Input.GetKeyDown(KeyCode.H))
        {
            animator.SetTrigger("Hit");
        }
    }
}