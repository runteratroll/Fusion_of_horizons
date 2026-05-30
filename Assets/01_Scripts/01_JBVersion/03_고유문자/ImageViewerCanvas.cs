using UnityEngine;
using UnityEngine.UI;

public class ImageViewerCanvas : MonoBehaviour
{
    public GameObject imageCanvas;
    public Image bigImage;

    private NearObjectImageViewer currentViewer;

    public void ShowImage(Sprite sprite, NearObjectImageViewer viewer)
    {
        currentViewer = viewer;

        imageCanvas.SetActive(true);
        bigImage.sprite = sprite;
        bigImage.preserveAspect = true;
    }

    public void HideImage(NearObjectImageViewer viewer)
    {
        if (currentViewer != viewer) return;

        imageCanvas.SetActive(false);
        bigImage.sprite = null;
        currentViewer = null;
    }
}