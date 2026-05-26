using UnityEngine;

public class AreaObject<T> : MonoBehaviour where T : Area
{
    public T ParentArea;

    public void SetParentArea(T area)
    {
        ParentArea = area;
    }
}
