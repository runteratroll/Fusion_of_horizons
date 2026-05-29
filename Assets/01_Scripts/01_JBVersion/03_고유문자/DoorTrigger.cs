using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private ShrinkDoorOnTouch[] targetDoors;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        foreach (ShrinkDoorOnTouch door in targetDoors)
        {
            door.PlayAnimation();
        }
    }
}