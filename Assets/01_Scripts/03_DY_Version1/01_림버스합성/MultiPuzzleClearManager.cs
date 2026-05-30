using UnityEngine;

public class MultiPuzzleClearManager : MonoBehaviour
{
    [Header("확인할 퍼즐들")]
    public ItemPuzzleManager[] puzzles;

    [Header("변경할 오브젝트들")]
    public ClearChangeObject[] changeObjects;

    private bool isActivated = false;

    public void CheckAllPuzzlesCleared()
    {
        if (isActivated)
            return;

        foreach (ItemPuzzleManager puzzle in puzzles)
        {
            if (!puzzle.IsCleared)
                return;
        }

        isActivated = true;

        foreach (ClearChangeObject obj in changeObjects)
        {
            obj.ApplyClearChange();
        }
    }
}