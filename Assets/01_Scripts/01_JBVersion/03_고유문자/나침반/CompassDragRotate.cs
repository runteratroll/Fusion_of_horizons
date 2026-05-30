using UnityEngine;
using UnityEngine.EventSystems;

public class CompassDragRotate : MonoBehaviour, IDragHandler
{
    [SerializeField] private RectTransform compassBody;

    [Header("Rotation")]
    [SerializeField] private float rotateSpeed = 1f;

    public void OnDrag(PointerEventData eventData)
    {
        float dragAmount = -eventData.delta.x;

        compassBody.Rotate(0, 0, dragAmount * rotateSpeed);
    }
}