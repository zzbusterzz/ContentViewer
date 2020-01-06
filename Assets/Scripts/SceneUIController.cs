using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class SceneUIController : MonoBehaviour
{
    private bool windowStatus_Minimised = false;

    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);
    [DllImport("user32.dll")]
    private static extern IntPtr GetActiveWindow();

    public void OnMinimise()
    {
        windowStatus_Minimised = true;
        SetWindowStatus();
    }

    public void OnMaximise()
    {
        windowStatus_Minimised = false;
        SetWindowStatus();
    }

    public void OnClose()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBPLAYER
                 Application.OpenURL(webplayerQuitURL);
        #else
                Application.Quit();
        #endif
    }

    private void SetWindowStatus()
    {
        if(windowStatus_Minimised)
            ShowWindow(GetActiveWindow(), 2);
        else
            ShowWindow(GetActiveWindow(), 3);
    }
}
