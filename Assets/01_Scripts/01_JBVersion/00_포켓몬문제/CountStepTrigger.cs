using UnityEngine;

public class CountStepTrigger : MonoBehaviour
{
    public CollectCountManager countManager;
    public SpriteChangeObject[] changeObjects;

    private bool activated = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (activated)
            return;

        if (!other.CompareTag("Player"))
            return;

        if (!countManager.HasEnoughItems())
            return;

        activated = true;

        foreach (SpriteChangeObject obj in changeObjects)
        {
            if (obj != null)
            {
                obj.ChangeSprite();
            }
        }
    }
}