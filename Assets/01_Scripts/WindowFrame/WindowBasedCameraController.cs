using UnityEngine;

public class WindowBasedCameraController : MonoBehaviour
{
    [SerializeField] private WindowValue windowValue;
    [SerializeField] private Camera targetCamera;

    [Header("기준 카메라")]
    [SerializeField] private Vector3 baseCameraPosition = new(0, 0, -10);
    [SerializeField] private float baseOrthographicSize = 5f;

    [Header("이동 강도")]
    [SerializeField] private float moveStrength = 1f;

    private Vector2Int baseWindowPosition;
    private Vector2Int baseWindowSize;

    private bool initialized;

    private void Awake()
    {
        if (targetCamera == null)
            targetCamera = Camera.main;
    }

    private void LateUpdate()
    {
        if (windowValue == null)
            return;

        if (!initialized)
        {
            InitBaseWindowValue();
            return;
        }

        UpdateCamera();
    }

    private void InitBaseWindowValue()
    {
        baseWindowPosition = windowValue.Position;
        baseWindowSize = windowValue.Size;

        if (baseWindowSize.x <= 0 || baseWindowSize.y <= 0)
            return;

        initialized = true;
    }

    private void UpdateCamera()
    {
        Vector2Int currentPosition = windowValue.Position;
        Vector2Int currentSize = windowValue.Size;

        // 현재 창의 네 변
        float left = currentPosition.x;
        float right = currentPosition.x + currentSize.x;
        float top = currentPosition.y;
        float bottom = currentPosition.y + currentSize.y;

        // 기준 창의 네 변
        float baseLeft = baseWindowPosition.x;
        float baseRight = baseWindowPosition.x + baseWindowSize.x;
        float baseTop = baseWindowPosition.y;
        float baseBottom = baseWindowPosition.y + baseWindowSize.y;

        // 각 변이 기준 위치에서 얼마나 변했는지
        float leftDelta = left - baseLeft;
        float rightDelta = right - baseRight;
        float topDelta = top - baseTop;
        float bottomDelta = bottom - baseBottom;

        // 좌우 변화량의 평균 = 창 중심의 X 변화량
        float centerDeltaX = (leftDelta + rightDelta) * 0.5f;

        // 상하 변화량의 평균 = 창 중심의 Y 변화량
        float centerDeltaY = (topDelta + bottomDelta) * 0.5f;

        // 픽셀 이동량을 기준 창 크기 대비 비율로 변환
        float xOffsetRatio = centerDeltaX / baseWindowSize.x;
        float yOffsetRatio = centerDeltaY / baseWindowSize.y;

        // 창 높이 변화 비율만큼 카메라 크기 변경
        float heightRatio = currentSize.y / (float)baseWindowSize.y;

        targetCamera.orthographicSize =
            baseOrthographicSize * heightRatio;

        // 이동량 계산은 현재 카메라 크기가 아니라 기준 카메라 크기 사용
        float baseWorldHeight = baseOrthographicSize * 2f;
        float baseAspect = baseWindowSize.x / (float)baseWindowSize.y;
        float baseWorldWidth = baseWorldHeight * baseAspect;

        Vector3 offset = new(
            -xOffsetRatio * baseWorldWidth * moveStrength,
             yOffsetRatio * baseWorldHeight * moveStrength,
            0f
        );

        targetCamera.transform.position =
            baseCameraPosition + offset;
    }
}