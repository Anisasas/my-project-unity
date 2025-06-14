using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryGameManager : MonoBehaviour
{
    public static MemoryGameManager Instance;

    public GameObject cardPrefab;
    public Transform cardParent;
    public Sprite[] cardImages;

    private List<Card> cards = new List<Card>();
    private Card firstCard, secondCard;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        CreateCards();
    }

    void CreateCards()
    {
        List<int> ids = new List<int>();
        for (int i = 0; i < cardImages.Length; i++)
        {
            ids.Add(i);
            ids.Add(i); // 2 of each
        }

        // Shuffle
        for (int i = 0; i < ids.Count; i++)
        {
            int temp = ids[i];
            int rand = Random.Range(i, ids.Count);
            ids[i] = ids[rand];
            ids[rand] = temp;
        }

        // Spawn cards
        for (int i = 0; i < ids.Count; i++)
        {
            GameObject cardObj = Instantiate(cardPrefab, cardParent);
            Card card = cardObj.GetComponent<Card>();
            card.SetCard(ids[i], cardImages[ids[i]]);
            cards.Add(card);
        }
    }

    public void CardRevealed(Card card)
    {
        if (firstCard == null)
        {
            firstCard = card;
        }
        else if (secondCard == null)
        {
            secondCard = card;
            StartCoroutine(CheckMatch());
        }
    }

    IEnumerator CheckMatch()
    {
        yield return new WaitForSeconds(1f);

        if (firstCard.id == secondCard.id)
        {
            firstCard.Disable();
            secondCard.Disable();
        }
        else
        {
            firstCard.Hide();
            secondCard.Hide();
        }

        firstCard = null;
        secondCard = null;
    }
}
