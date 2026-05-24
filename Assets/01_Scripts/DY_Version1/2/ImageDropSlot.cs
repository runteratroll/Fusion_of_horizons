using UnityEngine;
using UnityEngine.EventSystems;

public class ImageDropSlot : MonoBehaviour, IDropHandler
{
    public int correctNumber;

    private GameObject currentImage;
    private NumberImage currentNumberImage;

    public bool IsCorrect()
    {
        if (currentNumberImage == null)
            return false;

        return currentNumberImage.imageNumber == correctNumber;
    }

    public void OnDrop(PointerEventData eventData)
    {
        DraggableImage draggable =
            eventData.pointerDrag.GetComponent<DraggableImage>();

        if (draggable == null)
            return;

        GameObject clone = draggable.CloneObject;

        if (clone == null)
            return;

        NumberImage numberImage = clone.GetComponent<NumberImage>();

        if (numberImage == null)
            return;

        if (currentImage != null)
        {
            Destroy(currentImage);
        }

        clone.transform.SetParent(transform);
        clone.transform.localPosition = Vector3.zero;
        clone.transform.localScale = Vector3.one;

        CanvasGroup cg = clone.GetComponent<CanvasGroup>();
        if (cg != null)
            cg.blocksRaycasts = true;

        currentImage = clone;
        currentNumberImage = numberImage;
    }
}