using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class StepCounterManager : MonoBehaviour
{
    public static StepCounterManager Instance;

    public Action<int, int> OnUpdateStepCount = null;

    private int prevStepCount = 0;
    private int currentStepCount = 0;

    public int CurrentStepCount
    {
        get
        {
            return prevStepCount;
        }
        private set
        {
            if (currentStepCount == value) return;

            prevStepCount = currentStepCount;
            currentStepCount = value;
            OnUpdateStepCount?.Invoke(currentStepCount - prevStepCount, currentStepCount);
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        InputSystem.EnableDevice(StepCounter.current);
    }

    private void Update()
    {
        if (StepCounter.current != null)
        {
            if (StepCounter.current.enabled == true)
            {
                CurrentStepCount = StepCounter.current.stepCounter.ReadValue();
            }
        }
    }

    private void OnDisable()
    {
        InputSystem.DisableDevice(StepCounter.current);
    }
}
