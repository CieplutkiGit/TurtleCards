using UnityEngine;

public class CardsManager : Singleton<CardsManager>
{
    public CardScriptableObject[] cards;

    public CardScriptableObject[] playerCards;

    public void GetPlayerCards()
    {
        playerCards = new CardScriptableObject[4];
        PlayerPrefs.SetString("Cards", "1|1|3|2");
        string[] cardsID = PlayerPrefs.GetString("Cards").Split("|");

        for (int i = 0; i < playerCards.Length; i++)
        {
            playerCards[i] = cards[int.Parse(cardsID[i])];
        }
    }
}
