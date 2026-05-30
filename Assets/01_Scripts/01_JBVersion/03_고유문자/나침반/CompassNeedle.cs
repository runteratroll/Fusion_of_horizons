using UnityEngine;

public class CompassNeedle : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private RectTransform northTarget;

    [Header("UI")]
    [SerializeField] private RectTransform needleRect;

    [Header("Offset")]
    [SerializeField] private float angleOffset = 0f;

    public void SetNorthTarget(RectTransform newTarget)
    {
        northTarget = newTarget;
    }

    private void Update()
    {
        Vector2 direction =
    northTarget.anchoredPosition -
    needleRect.anchoredPosition;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        needleRect.rotation = Quaternion.Euler(0, 0, angle + angleOffset);
    }
}