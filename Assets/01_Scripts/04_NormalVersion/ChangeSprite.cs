using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    [Header("바꿀 대상 오브젝트")]
    public SpriteRenderer targetSpriteRenderer;

    [Header("바뀔 스프라이트")]
    public Sprite changedSprite;

    [Header("꺼질 콜라이더")]
    public Collider2D targetCollider;

    private bool used = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (used) return;

        if (other.CompareTag("Player"))
        {
            used = true;

            if (targetSpriteRenderer != null)
                targetSpriteRenderer.sprite = changedSprite;

            if (targetCollider != null)
                targetCollider.enabled = false;
        }
    }
}
