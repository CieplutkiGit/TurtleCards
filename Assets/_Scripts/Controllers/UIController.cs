using UnityEngine;
using UnityEngine.UI;

public class UIController : Singleton<UIController>
{
    public GameObject cardPrefab;
    public Transform botPanel;

    public void SpawnCards()
    {
        for (int i = 0; i < CardsManager.Instance.playerCards.Length; i++)
        {
            GameObject newCard = Instantiate(cardPrefab,botPanel.transform);
            
        }
    }

}
