using UnityEngine;

public class Costumes : Area3Obj
{
    public int Order;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            ParentArea.SelectCostume(this);
        }
    }



}
