using UnityEngine;

public class VisibleWorldBounds : MonoBehaviour, IClampBoundsProvider
{
    public Camera targetCamera;

    public Vector2 Min { get; private set; }
    public Vector2 Max { get; private set; }

    public Bounds GetBounds()
    {
        Vector3 center = (Min + Max) * 0.5f;
        Vector3 size = Max - Min;

        return new Bounds(center, size);
    }

    private void Awake()
    {
        if (targetCamera == null)
            targetCamera = Camera.main;
    }

    private void LateUpdate()
    {
        float zDistance = -targetCamera.nearClipPlane;

        Vector3 bottomLeft = targetCamera.ScreenToWorldPoint(
            new Vector3(0, 0, zDistance)
        );

        Vector3 topRight = targetCamera.ScreenToWorldPoint(
            new Vector3(Screen.width, Screen.height, zDistance)
        );

        Min = bottomLeft;
        Max = topRight;
    }
}