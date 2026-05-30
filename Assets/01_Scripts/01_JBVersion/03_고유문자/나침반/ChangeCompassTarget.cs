using UnityEngine;

public class ChangeCompassTarget : MonoBehaviour
{
    public CompassNeedle compass;
    public RectTransform newNorthTarget;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            compass.SetNorthTarget(newNorthTarget);
        }
    }
}