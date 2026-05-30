using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPuzzleManager : MonoBehaviour
{
    [Header("정답 아이템 번호")]
    public int[] correctItemNumbers = new int[4];

    [Header("공용 체크 마크 프리팹")]
    public GameObject markPrefab;

    [Header("클리어 시 나타날 이미지")]
    public GameObject clearImage;

    [Header("전체 퍼즐 클리어 매니저")]
    public MultiPuzzleClearManager multiPuzzleClearManager;

    public bool IsCleared => isCleared;

    private int correctCount = 0;
    private bool isCleared = false;

    private List<TouchItem> touchedItems = new List<TouchItem>();
    private List<GameObject> spawnedMarks = new List<GameObject>();

    public void CheckItem(TouchItem item)
    {
        if (isCleared)
            return;

        if (item.IsTouched)
            return;

        item.SetTouched(true);
        touchedItems.Add(item);

        GameObject mark = Instantiate(
            markPrefab,
            item.transform.position ,
            Quaternion.identity
        );

        spawnedMarks.Add(mark);

        if (IsCorrectItem(item.itemNumber))
        {
            correctCount++;

            if (correctCount >= correctItemNumbers.Length)
            {
                Debug.Log("맞혔다.");
                ClearPuzzle();
            }
        }
    }

    private void ClearPuzzle()
    {
        isCleared = true;

   

        if (clearImage != null )
        {
            clearImage.SetActive(true);
           
        }

        if (multiPuzzleClearManager != null)
        {
            multiPuzzleClearManager.CheckAllPuzzlesCleared();
        }
    }

    public void ResetPuzzle()
    {
        if (isCleared)
            return;

        correctCount = 0;
    

        foreach (TouchItem item in touchedItems)
        {
            if (item != null)
                item.SetTouched(false);
        }

        touchedItems.Clear();

        foreach (GameObject mark in spawnedMarks)
        {
            if (mark != null)
                Destroy(mark);
        }

        spawnedMarks.Clear();
    }

    private bool IsCorrectItem(int number)
    {
        for (int i = 0; i < correctItemNumbers.Length; i++)
        {
            if (correctItemNumbers[i] == number)
                return true;
        }

        return false;
    }
}