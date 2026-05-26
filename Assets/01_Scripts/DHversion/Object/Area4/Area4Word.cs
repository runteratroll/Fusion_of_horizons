using UnityEngine;

public class Area4Word : Area4Obj
{
    public string Word;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            ParentArea.AddWord(this);
        }
    }
}
