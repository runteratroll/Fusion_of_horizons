using UnityEngine;

public class Area1Food : Area1Obj
{
    public enum EFoodName
    {
        Grapefruit, // 자몽
        MalaHotPot, // 마라탕
        Samgyetang, // 삼계탕
        ScorchedRice, // 누룽지
    }

    public EFoodName FoodName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ParentArea.SelectFood(this);
        }
    }
}
