using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Targets")]
    public Transform player1; // Drag Medea here
    public Transform player2; // Drag Player 2 (or a Dummy) here

    [Header("Settings")]
    public float smoothSpeed = 0.125f; // How fast the camera follows (0.1 is smooth, 1 is instant)
    public Vector3 offset;             // The starting distance of the camera

    void Start()
    {
        // Automatically calculate the offset based on where you put the camera in the Scene
        // This prevents the camera from snapping to 0,0,0 immediately.
        if (player1 != null && player2 != null)
        {
            Vector3 centerPoint = (player1.position + player2.position) / 2;
            offset = transform.position - centerPoint;
        }
    }

    void LateUpdate()
    {
        if (player1 == null || player2 == null)
            return;

        // 1. Find the center point between the two players
        Vector3 centerPoint = (player1.position + player2.position) / 2;

        // 2. Calculate where the camera should be
        Vector3 desiredPosition = centerPoint + offset;

        // 3. Smoothly move the camera to that position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}