using UnityEngine;

public class CardsManager : Singleton<CardsManager>
{
    public CardScriptableObject[] cards;

    public CardScriptableObject[] playerCards;

    public GameObject[] slots;

    public int nextCard;

    protected override void Awake()
    {
        base.Awake();
        slots = new GameObject[4];
    }

    public void GetPlayerCards()
    {
        playerCards = new CardScriptableObject[7];
        PlayerPrefs.SetString("Cards", "0|1|2|3|1|1|3|2");
        string[] cardsID = PlayerPrefs.GetString("Cards").Split("|");

        for (int i = 0; i < playerCards.Length; i++)
        {
            playerCards[i] = cards[int.Parse(cardsID[i])];
        }
        for (int i = 0; i < slots.Length; i++)
        {
            SpawnCard();
        }
    }

    public void SpawnCard()
    {
        if (nextCard >= playerCards.Length) nextCard = 0;

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] == null)
            {
                var card = UIController.Instance.SpawnCards(playerCards[nextCard]);
                slots[i] = card;
                break;
            }
        }
        nextCard += 1;
    }
}
