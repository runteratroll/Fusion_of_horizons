using System.Collections;
using UnityEngine;
using Unity.Cinemachine;

public class CameraMoveTrigger2D : MonoBehaviour
{
    [Header("시네머신 카메라")]
    public CinemachineCamera virtualCamera;

    [Header("플레이어 이동 스크립트")]
    public MonoBehaviour playerMovementScript;


    [Header("비활성화될 오브젝트")]
    public GameObject Bg_Black;

    [Header("카메라 시작 위치")]
    public Transform startPoint;

    [Header("카메라 멈출 위치")]
    public Transform stopPoint;

    [Header("이동 속도")]
    public float moveSpeed = 3f;

    [Header("변경할 카메라 사이즈")]
    public float targetCameraSize = 8f;

    [Header("카메라 줌 속도")]
    public float zoomSpeed = 3f;

    private bool isMoving = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (isMoving)
            return;

        StartCoroutine(MoveCamera());
    }

    private IEnumerator MoveCamera()
    {
        isMoving = true;

        if (playerMovementScript != null)
            playerMovementScript.enabled = false;

        virtualCamera.Follow = null;

        Transform camTransform = virtualCamera.transform;
        Bg_Black.SetActive(false);

        // 시작 위치 강제 지정
        if (startPoint != null)
        {
            camTransform.position = new Vector3(
                startPoint.position.x,
                startPoint.position.y,
                camTransform.position.z
            );
        }

        while (
            Vector2.Distance(camTransform.position, stopPoint.position) > 0.05f ||
            Mathf.Abs(virtualCamera.Lens.OrthographicSize - targetCameraSize) > 0.05f
        )
        {
            camTransform.position = Vector3.MoveTowards(
                camTransform.position,
                new Vector3(
                    stopPoint.position.x,
                    stopPoint.position.y,
                    camTransform.position.z
                ),
                moveSpeed * Time.deltaTime
            );

            float newSize = Mathf.MoveTowards(
                virtualCamera.Lens.OrthographicSize,
                targetCameraSize,
                zoomSpeed * Time.deltaTime
            );

            virtualCamera.Lens.OrthographicSize = newSize;

            yield return null;
        }

        virtualCamera.Lens.OrthographicSize = targetCameraSize;
    }
}