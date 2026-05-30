using UnityEngine;

public class TeleportOnKey : MonoBehaviour
{
    [SerializeField] private Transform targetPosition;

    private Transform playerInTrigger;

    private void Update()
    {
        if (playerInTrigger == null)
            return;

        if (Input.GetKey(KeyCode.Alpha4) &&
    Input.GetKeyDown(KeyCode.L))
        {
            playerInTrigger.position = targetPosition.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        playerInTrigger = other.transform;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (playerInTrigger == other.transform)
        {
            playerInTrigger = null;
        }
    }
}