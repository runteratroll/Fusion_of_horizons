using UnityEngine;
using UnityEngine.UI;

public class ObjectImageCollector : MonoBehaviour
{
    [SerializeField] private GameObject canvasB;

    private CollectableImageObject currentObject;
    private GameObject currentCanvasA;

    private void Start()
    {
        canvasB.SetActive(false);
    }

    private void Update()
    {
        if (currentObject != null && Input.GetKeyDown(KeyCode.L))
        {
            UnlockObject(currentObject);
        }
    }

    private void UnlockObject(CollectableImageObject obj)
    {
        currentCanvasA = obj.relatedCanvasA;

        Sprite sprite = obj.GetSprite();

        if (sprite != null && obj.relatedButtonImageB != null)
        {
            obj.relatedButtonImageB.sprite = sprite;
            obj.relatedButtonImageB.gameObject.SetActive(true);
        }

        obj.relatedButtonB.gameObject.SetActive(true);
        obj.relatedButtonB.onClick.RemoveAllListeners();
        obj.relatedButtonB.onClick.AddListener(() =>
        {
            OpenCanvasA(obj.relatedCanvasA);
        });

        OpenCanvasA(obj.relatedCanvasA);

        Destroy(obj.gameObject);
    }

    private void OpenCanvasA(GameObject canvasA)
    {
        canvasB.SetActive(false);

        currentCanvasA = canvasA;
        currentCanvasA.SetActive(true);
    }

    public void CloseCurrentCanvasA()
    {
        if (currentCanvasA != null)
        {
            currentCanvasA.SetActive(false);
        }

        canvasB.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CollectableImageObject obj =
            other.GetComponent<CollectableImageObject>();

        if (obj != null)
        {
            currentObject = obj;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        CollectableImageObject obj =
            other.GetComponent<CollectableImageObject>();

        if (obj == currentObject)
        {
            currentObject = null;
        }
    }
}