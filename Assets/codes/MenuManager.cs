using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenuCanvas;
    public GameObject creditsCanvas;
    public GameObject gamesCanvas;
    public GameObject toolsCanvas;
    public GameObject settingsCanvas;

    void Start()
    {
        switch (SceneLoadData.menuToShow)
        {
            case "Credits":
                ShowCredits();
                break;
            case "Games":
                ShowGames();
                break;
            case "Tools":
                ShowTools();
                break;
            case "Settings":
                ShowSettings();
                break;
            default:
                ShowMainMenu();
                break;
        }

        SceneLoadData.menuToShow = "Main";
    }


    public void DisableAllCanvases()
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

    public void StartLabyrinth()
    {
        SceneManager.LoadScene("Labirintas");
    }
    public void StartSkaiciuotuvas()
    {
        SceneManager.LoadScene("skaiciuotuvas");
    }

    public void StartReacionTest()
    {
        SceneManager.LoadScene("Reacion test");
    }

}
