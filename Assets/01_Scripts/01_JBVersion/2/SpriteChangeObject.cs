using UnityEngine;

public class SpriteChangeObject : MonoBehaviour
{
    public Sprite changedSprite;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeSprite()
    {
        if (spriteRenderer != null && changedSprite != null)
        {
            spriteRenderer.sprite = changedSprite;
        }
    }
}