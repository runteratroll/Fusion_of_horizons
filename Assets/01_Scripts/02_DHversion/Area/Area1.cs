using UnityEngine;

public class Area1 : Area
{
    public Area1Food selectFood;

    public void SelectFood(Area1Food food)
    {
        selectFood?.gameObject.SetActive(true);
        selectFood = food;
        selectFood?.gameObject.SetActive(false);
    }
}
