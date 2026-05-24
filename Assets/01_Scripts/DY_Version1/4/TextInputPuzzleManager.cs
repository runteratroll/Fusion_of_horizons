using TMPro;
using UnityEngine;

public class TextInputPuzzleManager : MonoBehaviour
{
    [Header("입력 캔버스")]
    public GameObject inputCanvas;

    [Header("TMP 인풋 필드")]
    public TMP_InputField inputField;

    [Header("정답")]
    public string correctAnswer;

    [Header("결과 텍스트")]
    public TextMeshProUGUI resultText;

    [Header("변경될 오브젝트")]
    public SpriteRenderer targetObject;

    [Header("정답 시 바뀔 이미지")]
    public Sprite changedSprite;

    [Header("정답 시 나타날 오브젝트들")]
    public GameObject[] showGameObject;

    private Collider2D targetCollider;

    private bool isCleared = false;

    void Start()
    {
        inputCanvas.SetActive(false);

        if (targetObject != null)
        {
            targetCollider = targetObject.GetComponent<Collider2D>();
        }

        foreach (GameObject obj in showGameObject)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }

    }

    // 퍼즐창 열기
    public void OpenCanvas()
    {
        if (isCleared)
            return;

        inputCanvas.SetActive(true);

        inputField.text = "";
        inputField.ActivateInputField();
    }

    public void CloseCanvas()
    {
        if (isCleared)
            return;

        inputCanvas.SetActive(false);

        inputField.text = "";
        inputField.ActivateInputField();
    }


    // 확인 버튼
    public void CheckAnswer()
    {
        if (isCleared)
            return;

        string playerInput = inputField.text.Trim();

        if (playerInput == correctAnswer)
        {
            isCleared = true;

            resultText.text = "Clear";

            inputCanvas.SetActive(false);

            // 이미지 변경
            if (targetObject != null && changedSprite != null)
            {
                targetObject.sprite = changedSprite;
            }

            // 콜라이더 제거
            if (targetCollider != null)
            {
                targetCollider.enabled = false;
            }

            // 오브젝트 활성화
            foreach (GameObject obj in showGameObject)
            {
                if (obj != null)
                {
                    obj.SetActive(true);
                }
            }
        }
        else
        {
            resultText.text = "No";

            inputField.text = "";
            inputField.ActivateInputField();
        }
    }
}
