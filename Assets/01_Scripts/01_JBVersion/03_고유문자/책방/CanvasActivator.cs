using UnityEngine;

public class CanvasActivator : MonoBehaviour
{
    [SerializeField] private GameObject targetCanvas;

    private void Start()
    {
        if (targetCanvas != null)
            targetCanvas.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            targetCanvas.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            targetCanvas.SetActive(false);
        }
    }
}