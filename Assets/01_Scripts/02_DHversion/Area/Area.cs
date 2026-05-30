using UnityEngine;

public class Area : MonoBehaviour
{
    public GameObject Obstacle;
    public AreaGoal Goal;


    private void OnTriggerEnter2D(Collider2D other)
    {
        OnAreEnter(other);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        OnAreaExit(other);
    }

    public virtual void OnAreEnter(Collider2D other)
    {

    }

    public virtual void OnAreaExit(Collider2D other)
    {

    }
}
