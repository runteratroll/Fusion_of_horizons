using UnityEngine;
using UnityEngine.UI;

public class CollectableImageObject : MonoBehaviour
{
    public SpriteRenderer objectSprite;
    public GameObject relatedCanvasA;
    public Button relatedButtonB;
    public Image relatedButtonImageB;



    private void Reset()
    {
        objectSprite = GetComponent<SpriteRenderer>();
    }

    public Sprite GetSprite()
    {
        if (objectSprite == null) return null;
        return objectSprite.sprite;
    }
}