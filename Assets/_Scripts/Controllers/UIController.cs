using System.Collections.Generic;
using UnityEngine;

public class UIController : Singleton<UIController>
{
    public GameObject cardPrefab;

    public Transform botPanel;

    public Canvas mainCanvas;

    public (GameObject card, int cardID)
    SpawnCards(CardScriptableObject cardToSpawn)
    {
        GameObject Card = Instantiate(cardPrefab, botPanel.transform);

        Card cardScript = Card.GetComponent<Card>();

        cardScript.cardID = cardToSpawn.cardID;
        cardScript.cardSplashArt = cardToSpawn.cardSplashArt;
        cardScript.canvas = mainCanvas;
        cardScript.unit = cardToSpawn.unit;

        return (Card, cardScript.cardID);
    }
}
