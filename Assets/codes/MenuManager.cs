using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenuCanvas;
    public GameObject creditsCanvas;
    public GameObject gamesCanvas;
    public GameObject toolsCanvas;
    public GameObject settingsCanvas;

    void Start()
    {
        ShowMainMenu();
    }

    void DisableAllCanvases()
    {
        mainMenuCanvas.SetActive(false);
        creditsCanvas.SetActive(false);
        gamesCanvas.SetActive(false);
        toolsCanvas.SetActive(false);
        settingsCanvas.SetActive(false);
    }

    public void ShowMainMenu()
    {
        DisableAllCanvases();
        mainMenuCanvas.SetActive(true);
    }

    public void ShowCredits()
    {
        DisableAllCanvases();
        creditsCanvas.SetActive(true);
    }

    public void ShowGames()
    {
        DisableAllCanvases();
        gamesCanvas.SetActive(true);
    }

    public void ShowTools()
    {
        DisableAllCanvases();
        toolsCanvas.SetActive(true);
    }

    public void ShowSettings()
    {
        DisableAllCanvases();
        settingsCanvas.SetActive(true);
    }
}
