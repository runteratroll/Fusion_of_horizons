using UnityEngine;

public class StoneDoorTrigger : MonoBehaviour
{
    public bool IsPressed { get; private set; }

    private int stoneCount;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PickupObject>() == null)
            return;

        stoneCount++;
        IsPressed = true;

        Debug.Log(gameObject.name + " 눌림");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<PickupObject>() == null)
            return;

        stoneCount--;

        if (stoneCount <= 0)
        {
            stoneCount = 0;
            IsPressed = false;

            Debug.Log(gameObject.name + " 해제");
        }
    }
}