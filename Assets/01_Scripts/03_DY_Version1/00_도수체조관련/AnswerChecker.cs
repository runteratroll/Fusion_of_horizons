using UnityEngine;
using TMPro;

public class AnswerChecker : MonoBehaviour
{
    [Header("드롭 패널들")]
    public ImageDropSlot[] panels;

    [Header("결과 메시지")]
    public TextMeshProUGUI messageText;

    [Header("정답 시 이미지가 바뀌고 콜라이더가 꺼질 오브젝트")]
    public SpriteRenderer targetObject;

    [Header("정답 시 바뀔 이미지")]
    public Sprite clearSprite;

    private Collider2D targetCollider;
    private bool isCleared = false;

    private void Start()
    {
        if (targetObject != null)
        {
            targetCollider = targetObject.GetComponent<Collider2D>();
        }
    }

    public void CheckAnswer()
    {
        if (isCleared)
            return;

        foreach (ImageDropSlot panel in panels)
        {
            if (!panel.IsCorrect())
            {
                if (messageText != null)
                    messageText.text = "No";

                return;
            }
        }

        ClearPuzzle();
    }

    private void ClearPuzzle()
    {
        isCleared = true;

        if (messageText != null)
            messageText.text = "Clear!";

        // 이미지 변경
        if (targetObject != null && clearSprite != null)
        {
            targetObject.sprite = clearSprite;
        }

        // 콜라이더 끄기
        if (targetCollider != null)
        {
            targetCollider.enabled = false;
        }
    }
}