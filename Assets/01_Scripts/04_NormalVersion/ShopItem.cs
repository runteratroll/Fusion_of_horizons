using UnityEngine;
using TMPro;

public class ShopItem : MonoBehaviour
{
    [Header("아이템 가격")]
    public int itemPrice = 5;

    [Header("돈 매니저")]
    public MoneyManager moneyManager;

    [Header("구매 성공 시 활성화될 오브젝트")]
    public GameObject boughtObject;

    [Header("결과 텍스트")]
    public TextMeshProUGUI resultText;

    private bool isBought = false;

    public void BuyItem()
    {
        if (isBought)
            return;

        bool success = moneyManager.UseMoney(itemPrice);

        if (success)
        {
            isBought = true;

            if (resultText != null)
                resultText.text = "구매 완료";

            if (boughtObject != null)
                boughtObject.SetActive(true);
        }
        else
        {
            if (resultText != null)
                resultText.text = "돈이 부족합니다";
        }
    }
}