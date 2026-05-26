using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StepOrderPuzzleManager : MonoBehaviour
{
    [Header("정답 순서")]
    public StepOrderObject[] correctSequence;

    [Header("공용 번호 이미지 프리팹")]
    public GameObject stepMarkPrefab;

    [Header("정답시 나타날 오브젝트")]
    public GameObject[] clearObject;

    private int currentStep = 0;
    private bool isCleared = false;

    private List<GameObject> spawnedMarks = new List<GameObject>();
    private List<StepOrderObject> steppedObjects = new List<StepOrderObject>();

    public void StepOnObject(StepOrderObject obj)
    {
        if (isCleared)
            return;

        if (obj.Stepped)
            return;

        currentStep++;

        obj.SetStepped(true);
        steppedObjects.Add(obj);

        // 공용 이미지 생성
        GameObject mark = Instantiate(
            stepMarkPrefab,
            obj.transform.position,
            Quaternion.identity
        );

        spawnedMarks.Add(mark);

        // 번호 표시
        TextMeshPro text = mark.GetComponentInChildren<TextMeshPro>();

        if (text != null)
        {
            text.text = currentStep.ToString();
        }

        // 정답 검사
        StepOrderObject correctObj = correctSequence[currentStep - 1];

        if (obj != correctObj)
        {
            Debug.Log("순서틀림");

            ResetPuzzle();
            return;
        }

        // 클리어
        if (currentStep >= correctSequence.Length)
        {
            isCleared = true;

            foreach(GameObject objedt in clearObject)
            {
                if(objedt != null)
                {
                    objedt.SetActive(true);
                }
            }
            Debug.Log("맞음");
        }
    }

    public void ResetPuzzle()
    {
        currentStep = 0;

        foreach (StepOrderObject obj in steppedObjects)
        {
            if (obj != null)
                obj.SetStepped(false);
        }

        steppedObjects.Clear();

        foreach (GameObject mark in spawnedMarks)
        {
            if (mark != null)
                Destroy(mark);
        }

        spawnedMarks.Clear();
    }
}