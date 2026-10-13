using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    public GameObject panel;
    public Button openButton;
    public Button closeButton;

    void Start()
    {
        panel.SetActive(false);
        closeButton.gameObject.SetActive(false);
        openButton.gameObject.SetActive(true);

        openButton.onClick.AddListener(OpenPanel);
        closeButton.onClick.AddListener(ClosePanel);
    }

    public void OpenPanel()
    {
        panel.SetActive(true);
        openButton.gameObject.SetActive(false);
        closeButton.gameObject.SetActive(true);
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
        openButton.gameObject.SetActive(true);
        closeButton.gameObject.SetActive(false);
    }
}
