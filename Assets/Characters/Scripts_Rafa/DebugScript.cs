using UnityEngine;

public class DebugTriggerTest : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("🔥 TRIGGER HIT cu: " + other.name);
    }
}
