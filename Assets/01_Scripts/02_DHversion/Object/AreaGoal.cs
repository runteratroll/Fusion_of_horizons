using UnityEngine;

public class AreaGoal : AreaObject<Area>
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (ParentArea.Obstacle != null)
            {
                ParentArea.Obstacle.SetActive(false);
            }
            this.gameObject.SetActive(false);
        }
    }
}
