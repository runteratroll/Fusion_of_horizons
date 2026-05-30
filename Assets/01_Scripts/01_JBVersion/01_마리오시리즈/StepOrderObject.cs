using UnityEngine;

public class StepOrderObject : MonoBehaviour
{
    private bool stepped = false;

    public bool Stepped => stepped;

    public void SetStepped(bool value)
    {
        stepped = value;
    }
}