using UnityEngine;

public class UniversalFighterMovement : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 4f;
    public float jumpForce = 6f;

    [Header("Controls")]
    public KeyCode leftKey;
    public KeyCode rightKey;

    [Header("Opponent")]
    public Transform enemy;

    [Header("Visual Model (mesh only)")]
    public Transform model;

    private float moveInput;
    private Animator anim;

    private const string VELOCITY = "Velocity";

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (enemy == null || model == null) return;

        ReadInput();
        Move();
        FaceEnemy();
        UpdateAnimator();
    }

    
    // INPUT 
   
    void ReadInput()
    {
        moveInput = 0f;

        if (Input.GetKey(rightKey))
            moveInput = 1f;
        else if (Input.GetKey(leftKey))
            moveInput = -1f;
    }

    
    // MOVEMENT (AXA Z)
   
    void Move()
    {
        transform.Translate(Vector3.forward * moveInput * speed * Time.deltaTime);
    }

   
    // ALWAYS FACE ENEMY
   
    void FaceEnemy()
    {
        Vector3 scale = model.localScale;

        if (enemy.position.x > transform.position.x)
            scale.x = Mathf.Abs(scale.x);
        else
            scale.x = -Mathf.Abs(scale.x);

        model.localScale = scale;
    }

   
    // ANIMATION
  
    void UpdateAnimator()
    {
        if (anim != null)
            anim.SetFloat(VELOCITY, Mathf.Abs(moveInput));
    }
}
