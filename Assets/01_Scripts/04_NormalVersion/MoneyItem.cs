using UnityEngine;

public class MoneyItem : MonoBehaviour
{
    public int amount = 1;
    public MoneyManager moneyManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        moneyManager.AddMoney(amount);
        Destroy(gameObject);
    }
}