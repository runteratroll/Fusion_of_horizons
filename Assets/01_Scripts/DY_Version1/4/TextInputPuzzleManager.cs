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

    private bool isCleared = false;

    void Start()
    {
        inputCanvas.SetActive(false);
    }

    // 퍼즐 시작
    public void OpenCanvas()
    {
        if (isCleared)
            return;

        inputCanvas.SetActive(true);

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

            resultText.text = "Clear!";

            inputCanvas.SetActive(false);
        }
        else
        {

            resultText.text = "No";

            inputField.text = "";
            inputField.ActivateInputField();
        }
    }
}
