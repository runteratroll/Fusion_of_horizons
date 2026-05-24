using UnityEngine;

public class TextPuzzleTrigger2D : MonoBehaviour
{
    public TextInputPuzzleManager puzzleManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            puzzleManager.OpenCanvas();
        }
    }
}