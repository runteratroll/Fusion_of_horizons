using UnityEngine;

public class MultiPlateDoor : MonoBehaviour
{
    [SerializeField] private StoneDoorTrigger[] plates;

    [SerializeField] private Vector3 closedScale = Vector3.one;
    [SerializeField] private Vector3 openScale = new Vector3(1f, 0.2f, 1f);

    private void Update()
    {
        bool allPressed = true;

        foreach (StoneDoorTrigger plate in plates)
        {
            if (!plate.IsPressed)
            {
                allPressed = false;
                break;
            }
        }

        transform.localScale =
            allPressed ? openScale : closedScale;
    }
}