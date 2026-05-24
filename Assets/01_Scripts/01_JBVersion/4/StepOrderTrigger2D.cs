using UnityEngine;

public class StepOrderTrigger2D : MonoBehaviour
{
    public StepOrderPuzzleManager puzzleManager;

    private StepOrderObject stepObject;

    private void Awake()
    {
        stepObject = GetComponent<StepOrderObject>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            puzzleManager.StepOnObject(stepObject);
        }
    }
}