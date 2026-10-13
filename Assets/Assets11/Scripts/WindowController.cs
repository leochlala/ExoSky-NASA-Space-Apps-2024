using UnityEngine;
using UnityEngine.UI;

public class WindowControl : MonoBehaviour
{
    public Button minimizeButton;
    public Button closeButton;

    void Start()
    {
        if (minimizeButton != null)
            minimizeButton.onClick.AddListener(Minimize);

        if (closeButton != null)
            closeButton.onClick.AddListener(CloseApp);
    }

    public void Minimize()
    {
#if UNITY_STANDALONE_WIN
        var handle = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
        ShowWindow(handle, 2);
#endif
    }

    public void CloseApp()
    {
        Application.Quit();
    }

    [System.Runtime.InteropServices.DllImport("user32.dll")]
    private static extern bool ShowWindow(System.IntPtr hWnd, int nCmdShow);
}
