using UnityEngine;

/*public class GameManager : MonoBehaviour
{
    public GameObject finishCanvas;

    void Start()
    {
        if (finishCanvas != null)
            finishCanvas.SetActive(false); // Automatiškai paslepia pabaigos ekraną
    }

    public void WinGame()
    {
        if (finishCanvas != null)
        {
            finishCanvas.SetActive(true);
            Time.timeScale = 0f; // Sustabdo žaidimą
            Debug.Log("Victory!");
        }
        else
        {
            Debug.LogWarning("Finish Canvas not assigned in GameManager.");
        }
    }
}*/

public class GameManager : MonoBehaviour
{
    public GameObject winCanvas;

    void Start()
    {
        winCanvas.SetActive(false); // Paslepiame pradžioje
    }

    public void WinGame()
    {
        Debug.Log("Laimėjai!");
        winCanvas.SetActive(true);
    }
}