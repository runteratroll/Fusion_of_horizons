using UnityEngine;

public class CollectItem : MonoBehaviour
{
    public CollectCountManager countManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            countManager.AddCount();
            gameObject.SetActive(false);
        }
    }
}