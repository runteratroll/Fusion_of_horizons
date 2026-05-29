using UnityEngine;

public class TeleportTrigger : MonoBehaviour
{
    public Transform targetPoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = targetPoint.position;
        }
    }
}