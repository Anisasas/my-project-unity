using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public int id;
    public Image frontImage;  // <- Šitas greičiausiai NULL
    public GameObject front;  // Kortelės priekinė pusė
    public GameObject back;   // Kortelės galinė pusė

    private bool isRevealed = false;

    void Awake()
    {
        Hide();
    }

    public void SetCard(int newId, Sprite frontSprite)
    {
        id = newId;
        frontImage.sprite = frontSprite; // <- Čia meta NullReferenceException
    }

    public void OnClick()
    {
        if (!isRevealed)
        {
            Reveal();
            FindObjectOfType<MemoryGameManager>().CardRevealed(this);
        }
    }

    public void Reveal()
    {
        isRevealed = true;
        front.SetActive(true);
        back.SetActive(false);
    }

    public void Hide()
    {
        isRevealed = false;
        front.SetActive(false);
        back.SetActive(true);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
