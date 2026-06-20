using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class WindowValue : MonoBehaviour
{
    [Header("최소 클라이언트 영역 크기")]
    [SerializeField] private int minWidth = 480;
    [SerializeField] private int minHeight = 270;

    public Vector2Int Position { get; private set; }
    public Vector2Int Size { get; private set; }

#if UNITY_STANDALONE_WIN && !UNITY_EDITOR

    [StructLayout(LayoutKind.Sequential)]
    private struct RECT
    {
        public int left;
        public int top;
        public int right;
        public int bottom;
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct POINT
    {
        public int x;
        public int y;
    }

    [DllImport("user32.dll")]
    private static extern IntPtr GetActiveWindow();

    [DllImport("user32.dll")]
    private static extern bool GetClientRect(IntPtr hWnd, out RECT rect);

    [DllImport("user32.dll")]
    private static extern bool ClientToScreen(IntPtr hWnd, ref POINT point);

    private IntPtr _windowHandle;

#endif

    private void Start()
    {
#if UNITY_STANDALONE_WIN && !UNITY_EDITOR
        _windowHandle = GetActiveWindow();
#endif
    }

    private void Update()
    {
        UpdateWindowInfo();
    }

    private void UpdateWindowInfo()
    {
#if UNITY_STANDALONE_WIN && !UNITY_EDITOR

        if (_windowHandle == IntPtr.Zero)
            return;

        if (!GetClientRect(_windowHandle, out RECT rect))
            return;

        POINT topLeft = new POINT
        {
            x = rect.left,
            y = rect.top
        };

        ClientToScreen(_windowHandle, ref topLeft);

        Position = new Vector2Int(topLeft.x, topLeft.y);

        Size = new Vector2Int(
            rect.right - rect.left,
            rect.bottom - rect.top
        );

#else
        Position = Vector2Int.zero;
        Size = new Vector2Int(Screen.width, Screen.height);
#endif
    }
}