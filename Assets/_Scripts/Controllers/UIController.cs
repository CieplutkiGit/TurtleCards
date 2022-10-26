using UnityEngine;
using UnityEngine.UI;

public class UIController : Singleton<UIController>
{
    public GameObject cardPrefab;
    public Transform botPanel;
    public Canvas mainCanvas;

    public void SpawnCards()
    {
        for (int i = 0; i < CardsManager.Instance.playerCards.Length; i++)
        {
            GameObject Card = Instantiate(cardPrefab,botPanel.transform);
            Card CardScript = Card.GetComponent<Card>();
            CardScript.cardID = CardsManager.Instance.playerCards[i].cardID;
            CardScript.cardSplashArt = CardsManager.Instance.playerCards[i].cardSplashArt;
            CardScript.canvas = mainCanvas;
            CardScript.unit = CardsManager.Instance.playerCards[i].unit;
        }
    }

}
