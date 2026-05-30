using UnityEngine;
using UnityEngine.UI;

public class NearObjectImageViewer : MonoBehaviour
{
    [Header("플레이어")]
    public Transform player;

    [Header("거리 설정")]
    public float showDistance = 2f;

    [Header("공용 이미지 뷰어")]
    public ImageViewerCanvas imageViewerCanvas;

    [Header("이 오브젝트가 보여줄 이미지")]
    public Sprite imageToShow;

    private bool isShowing = false;

    private void Update()
    {
        if (player == null || imageViewerCanvas == null || imageToShow == null) return;

        float distance = Vector2.Distance(player.position, transform.position);

        if (distance <= showDistance)
        {
            imageViewerCanvas.ShowImage(imageToShow, this);
            isShowing = true;
        }
        else
        {
            if (isShowing)
            {
                imageViewerCanvas.HideImage(this);
                isShowing = false;
            }
        }
    }
}