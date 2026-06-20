using TMPro;
using UnityEngine;

public class Area1Shop : Area1Obj
{
    public TextMeshPro Text;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ParentArea.Obstacle.activeSelf == false) return;

        if(collision.CompareTag("Player"))
        {
            switch (ParentArea.selectFood.FoodName)
            {
                case Area1Food.EFoodName.Grapefruit:
                case Area1Food.EFoodName.MalaHotPot:
                case Area1Food.EFoodName.Samgyetang:
                    SetTextBubble(false);
                    break;
                case Area1Food.EFoodName.ScorchedRice:
                    SetTextBubble(true);
                    ParentArea.Goal.gameObject.SetActive(true);
                    break;
            }
        }
    }

    private void SetTextBubble(bool value)
    {
        Text.gameObject.SetActive(true);

        if(value)
        {
            Text.SetText("이거 좋아!");
        }
        else
        {
            Text.SetText("이거 싫어 다른거!");
        }
    }
}
