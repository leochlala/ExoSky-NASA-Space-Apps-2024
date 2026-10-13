using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject menuPanel;   
    public GameObject arrowButton; 
    public Button closeButton;     
    public Button arrowShowButton; 
    public GameObject anotherButton;   

    void Start()
    {
        
        menuPanel.SetActive(true);
        arrowButton.SetActive(false);
        anotherButton.SetActive(true); 

        
        closeButton.onClick.AddListener(HideMenu);
        arrowShowButton.onClick.AddListener(ShowMenu);
    }

    void HideMenu()
    {
        menuPanel.SetActive(false); 
        arrowButton.SetActive(true); 
        anotherButton.SetActive(false); 
    }

    void ShowMenu()
    {
        menuPanel.SetActive(true); 
        arrowButton.SetActive(false); 
        anotherButton.SetActive(true); 
    }
}
