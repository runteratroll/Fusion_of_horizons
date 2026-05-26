using UnityEngine;
using TMPro;

public class CollectCountManager : MonoBehaviour
{
    [Header("필요한 아이템 개수")]
    public int requiredCount = 3;


    private int currentCount = 0;

    public bool HasEnoughItems()
    {
        return currentCount >= requiredCount;
    }

    public void AddCount()
    {
        currentCount++;
    }
}