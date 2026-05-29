using System.Drawing;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    public static WindowManager Instance;

    public WindowValue windowValue;
    public Camera TargetCamera;

    // 1920, 1440을 size 5로 두고 작업
    [Header("Camera")]
    [SerializeField]
    private float baseOrthoSize = 5f;
    [SerializeField] private Vector3 basePosition = new(0, 0, -10);

    [Header("Reference Resolution")]
    [SerializeField]
    private float baseWidth = 960f;
    [SerializeField]
    private float baseHeight = 540f;

    [Header("Move Strength")]
    [SerializeField] private float moveStrength = 1f;

    private void Awake()
    {
        Instance = this;
    }

    private void LateUpdate()
    {
        UpdateCamera();
    }

    private void UpdateCamera()
    {
        int monitorWidth = Display.main.systemWidth;
        int monitorHeight = Display.main.systemHeight;

        Vector2Int pos = windowValue.Position;
        Vector2Int size = windowValue.Size;

        float left = pos.x;
        float right = pos.x + size.x;
        float top = pos.y;
        float bottom = pos.y + size.y;

        float baseLeft = (monitorWidth - baseWidth) * 0.5f;
        float baseRight = baseLeft + baseWidth;

        float baseTop = (monitorHeight - baseHeight) * 0.5f;
        float baseBottom = baseTop + baseHeight;

        float leftDelta = left - baseLeft;
        float rightDelta = right - baseRight;
        float topDelta = top - baseTop;
        float bottomDelta = bottom - baseBottom;

        float widthRatio = size.x / baseWidth;
        float heightRatio = size.y / baseHeight;

        TargetCamera.orthographicSize =
            baseOrthoSize * heightRatio;

        float worldHeight = TargetCamera.orthographicSize * 2f;
        float worldWidth = worldHeight * TargetCamera.aspect;

        float xOffsetRatio = (leftDelta + rightDelta) / baseWidth;
        float yOffsetRatio = (topDelta + bottomDelta) / baseHeight;

        Vector3 offset = new(
            xOffsetRatio * worldWidth * 0.5f * moveStrength,
            -yOffsetRatio * worldHeight * 0.5f * moveStrength,
            0f
        );

        TargetCamera.transform.position = basePosition + offset;
    }
}
