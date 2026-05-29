using UnityEngine;

public class WindowSizeTester : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            WindowController.Instance.SetWindowSize(640, 360);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            WindowController.Instance.SetWindowSize(1280, 720);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            WindowController.Instance.SetWindowSize(1600, 900);
        }
    }
}