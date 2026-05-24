using UnityEngine;

public class ResetObject : MonoBehaviour
{
    public ItemPuzzleManager puzzleManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            puzzleManager.ResetPuzzle();
        }
    }
}