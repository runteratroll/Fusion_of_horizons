using UnityEngine;

public class PlayerItemTouch2D : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        TouchItem item = other.GetComponent<TouchItem>();

        if (item != null)
        {
            item.Touch();
        }
    }
}