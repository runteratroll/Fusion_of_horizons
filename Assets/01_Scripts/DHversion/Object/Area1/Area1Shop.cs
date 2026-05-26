using UnityEngine;

public class Area1Shop : Area1Obj
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ParentArea.Obstacle.activeSelf == false) return;

        if(collision.CompareTag("Player"))
        {
            switch (ParentArea.selectFood.FoodName)
            {
                case Area1Food.EFoodName.Grapefruit:
                    break;
                case Area1Food.EFoodName.MalaHotPot:
                    break;
                case Area1Food.EFoodName.Samgyetang:
                    break;
                case Area1Food.EFoodName.ScorchedRice:
                    ParentArea.Goal.gameObject.SetActive(true);
                    break;
            }
        }
    }
}
