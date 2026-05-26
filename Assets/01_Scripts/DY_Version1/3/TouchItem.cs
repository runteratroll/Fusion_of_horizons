using UnityEngine;

public class TouchItem : MonoBehaviour
{
    public int itemNumber;
    public ItemPuzzleManager puzzleManager;

    private bool isTouched = false;

    public bool IsTouched => isTouched;

    public void SetTouched(bool value)
    {
        isTouched = value;
    }

    public void Touch()
    {
        if (puzzleManager != null)
        {
            puzzleManager.CheckItem(this);
        }
    }
}