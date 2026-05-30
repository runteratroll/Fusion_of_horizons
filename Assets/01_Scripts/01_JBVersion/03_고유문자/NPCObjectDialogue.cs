using UnityEngine;

public class NPCObjectDialogue : MonoBehaviour
{
    public GameObject[] dialogueObjects;

    private bool playerNear = false;
    private int currentIndex = -1;

    void Start()
    {
        HideAllDialogues();
    }

    void Update()
    {
        if (playerNear && Input.GetKeyDown(KeyCode.E))
        {
            ShowNextDialogue();
        }
    }

    void ShowNextDialogue()
    {
        if (dialogueObjects.Length == 0)
            return;

        if (currentIndex >= 0)
        {
            dialogueObjects[currentIndex].SetActive(false);
        }

        currentIndex++;

        if (currentIndex >= dialogueObjects.Length)
        {
            currentIndex = -1;
            return;
        }

        dialogueObjects[currentIndex].SetActive(true);
    }

    void HideAllDialogues()
    {
        foreach (GameObject obj in dialogueObjects)
        {
            obj.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = false;
            currentIndex = -1;
            HideAllDialogues();
        }
    }
}