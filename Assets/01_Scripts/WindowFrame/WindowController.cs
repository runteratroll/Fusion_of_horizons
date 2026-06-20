using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class WindowController : MonoBehaviour
{
    public static WindowController Instance { get; private set; }

#if UNITY_STANDALONE_WIN && !UNITY_EDITOR
    [StructLayout(LayoutKind.Sequential)]
    private struct RECT
    {
        public int left;
        public int top;
        public int right;
        public int bottom;
    }

    [DllImport("user32.dll")]
    private static extern IntPtr GetActiveWindow();

    [DllImport("user32.dll")]
    private static extern bool GetWindowRect(IntPtr hWnd, out RECT rect);

    [DllImport("user32.dll")]
    private static extern bool SetWindowPos(
        IntPtr hWnd,
        IntPtr hWndInsertAfter,
        int X,
        int Y,
        int cx,
        int cy,
        uint uFlags
    );

    private const uint SWP_NOZORDER = 0x0004;
    private const uint SWP_NOACTIVATE = 0x0010;

    private IntPtr windowHandle;
#endif

    public int Width { get; private set; }
    public int Height { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
#if UNITY_STANDALONE_WIN && !UNITY_EDITOR
        windowHandle = GetActiveWindow();
#endif
    }

    private void Update()
    {
        UpdateWindowSize();
    }

    private void UpdateWindowSize()
    {
#if UNITY_STANDALONE_WIN && !UNITY_EDITOR
        if (windowHandle == IntPtr.Zero)
            return;

        if (GetWindowRect(windowHandle, out RECT rect))
        {
            Width = rect.right - rect.left;
            Height = rect.bottom - rect.top;
        }
#else
        Width = Screen.width;
        Height = Screen.height;
#endif
    }

    public void SetWindowSize(int width, int height)
    {
#if UNITY_STANDALONE_WIN && !UNITY_EDITOR
        if (windowHandle == IntPtr.Zero)
            return;

        SetWindowPos(
            windowHandle,
            IntPtr.Zero,
            100,
            100,
            width,
            height,
            SWP_NOZORDER | SWP_NOACTIVATE
        );
#else
        Screen.SetResolution(width, height, false);
#endif
    }
}