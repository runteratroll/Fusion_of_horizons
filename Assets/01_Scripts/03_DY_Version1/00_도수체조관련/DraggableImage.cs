using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableImage : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private GameObject cloneObject;
    private RectTransform cloneRect;
    private Canvas canvas;

    public GameObject CloneObject => cloneObject;

    void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        cloneObject = Instantiate(gameObject, canvas.transform);
        cloneObject.name = gameObject.name + "_Clone";

        // 복사본에서는 이 스크립트 제거
        Destroy(cloneObject.GetComponent<DraggableImage>());

        CanvasGroup cg = cloneObject.GetComponent<CanvasGroup>();
        if (cg == null)
            cg = cloneObject.AddComponent<CanvasGroup>();

        cg.blocksRaycasts = false;

        cloneRect = cloneObject.GetComponent<RectTransform>();
        cloneRect.position = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (cloneRect != null)
            cloneRect.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // 드롭 실패했을 때만 복사본 삭제
        if (cloneObject != null && cloneObject.transform.parent == canvas.transform)
        {
            Destroy(cloneObject);
        }

        cloneObject = null;
        cloneRect = null;
    }
}
