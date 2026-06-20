using TMPro;
using UnityEngine;

public class StepCountEvent : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    private void Start()
    {
        StepCounterManager.Instance.OnUpdateStepCount += (sub, step) =>
        {
            text.SetText("Step: " + step);
            Debug.Log($"추가된 걸음 수 : {sub}, 현재 걸음 수 {step}");
        };
    }
}
