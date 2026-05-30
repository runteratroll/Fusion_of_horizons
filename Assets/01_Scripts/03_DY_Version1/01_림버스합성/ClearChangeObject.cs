using UnityEngine;

public class ClearChangeObject : MonoBehaviour
{
    [Header("변경될 이미지")]
    public Sprite clearSprite;

    private SpriteRenderer spriteRenderer;
    private Collider2D col;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }

    public void ApplyClearChange()
    {
        if (spriteRenderer != null && clearSprite != null)
        {
            spriteRenderer.sprite = clearSprite;
        }

        if (col != null)
        {
            col.enabled = false;
        }
    }
}