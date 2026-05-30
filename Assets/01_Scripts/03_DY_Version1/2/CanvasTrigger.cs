using UnityEngine;

public class CanvasTrigger : MonoBehaviour
{
    [Header("활성화할 캔버스")]
    public GameObject targetCanvas;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("닿았습니다");
        // 플레이어만 반응하게 하고 싶으면 태그 체크
        if (other.CompareTag("Player"))
        {
            targetCanvas.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            targetCanvas.SetActive(false);
        }
    }
}