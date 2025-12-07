using UnityEngine;

public class UniversalFighterMovement : MonoBehaviour
{
    [Header("⚙️ Movement")]
    public float moveSpeed = 5f;

    [Header("🎮 Controls")]
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;

    [Header("MODEL TO FLIP (Only the mesh!)")]
    public Transform model;

    private Rigidbody rb;
    private Animator anim;
    private float moveInput;

    private const string VELOCITY = "Velocity";

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();

      
        rb.freezeRotation = true;

        if (model == null)
            Debug.LogError("❌ Model is NOT assigned! Drag your mesh into the model field.");
    }

    void Update()
    {
        ReadInput();
        UpdateVisuals();
    }

    void FixedUpdate()
    {
        MoveCharacter();
    }

    private void ReadInput()
    {
        if (Input.GetKey(rightKey))
            moveInput = 1;
        else if (Input.GetKey(leftKey))
            moveInput = -1;
        else
            moveInput = 0;
    }

    private void MoveCharacter()
    {
        Vector3 velocity = rb.linearVelocity;
        velocity.x = moveInput * moveSpeed;
        rb.linearVelocity = velocity;
    }

    private void UpdateVisuals()
    {
        anim.SetFloat(VELOCITY, Mathf.Abs(moveInput));

        // Flip ONLY the mesh
        if (moveInput > 0)
            model.localRotation = Quaternion.Euler(0, 90, 0);
        else if (moveInput < 0)
            model.localRotation = Quaternion.Euler(0, -90, 0);
    }
}
