using UnityEngine;
using UnityEngine.UI;

public class AnswerChecker : MonoBehaviour
{
    public ImageDropSlot[] panels;
    public Text messageText;

    public void CheckAnswer()
    {
        foreach (ImageDropSlot panel in panels)
        {
            if (!panel.IsCorrect())
            {
                messageText.text = "틀렸습니다.";
                return;
            }
        }

        messageText.text = "정답을 맞혔습니다.";
    }
}