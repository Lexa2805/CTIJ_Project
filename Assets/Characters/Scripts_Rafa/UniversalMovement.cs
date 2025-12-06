using UnityEngine;

public class UniversalMovement : MonoBehaviour
{
    // Câmpuri configurabile
    [Header("⚙️ Setări Mișcare")]
    public float moveSpeed = 5.0f;

    // Referințe private
    private Animator animator;
    private Rigidbody rb;
    private float moveInput;

    // Numele parametrului Animator (doar pentru mers)
    private const string VELOCITY = "Velocity";


    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        // Asigură stabilitatea fizică
        if (rb != null)
        {
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        }
    }

    void Update()
    {
        // 1. Citirea Input-ului (A și D)
        ReadInput();

        // 2. Animație & Rotație
        UpdateGraphics();

        // NOTĂ: Funcția HandleJump a fost eliminată.
    }

    void FixedUpdate()
    {
        // 1. Mișcarea Fizică (Aplicarea vitezei pe Rigidbody)
        ApplyMovement();

        // NOTĂ: Funcția CheckIfGrounded a fost eliminată.
    }

    // --- Functii Simplificate ---

    private void ReadInput()
    {
        // Citim input-ul de mișcare stânga/dreapta (A și D)
        // Dacă D e apăsat: 1. Dacă A e apăsat: -1. Altfel: 0.
        moveInput = Input.GetKey(KeyCode.D) ? 1 : Input.GetKey(KeyCode.A) ? -1 : 0;
    }

    private void ApplyMovement()
    {
        // Aplicăm viteza pe Rigidbody (Doar pe axa X, păstrând Y pentru gravitație)
        Vector3 newVelocity = rb.linearVelocity;
        newVelocity.x = moveInput * moveSpeed;
        rb.linearVelocity = newVelocity;
    }

    private void UpdateGraphics()
    {
        float absoluteMoveInput = Mathf.Abs(moveInput);

        // Animație de Mers (Parametrul "Velocity")
        animator.SetFloat(VELOCITY, absoluteMoveInput);

        // Rotație
        if (absoluteMoveInput > 0.1f)
        {
            float rotationY = moveInput > 0 ? 90 : -90;
            transform.rotation = Quaternion.Euler(0, rotationY, 0);
        }
    }
}