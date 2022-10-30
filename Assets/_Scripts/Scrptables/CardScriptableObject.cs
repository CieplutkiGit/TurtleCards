using UnityEngine;

[
    CreateAssetMenu(
        fileName = "CardScriptableObject",
        menuName = "ScriptableObjects/Card")
]
public class CardScriptableObject : ScriptableObject
{
    public CardType cardType;

    public enum CardType
    {
        unit,
        building
    }

    public string cardName;

    public int cardID;

    public Sprite cardSplashArt;

    public UnitScriptableObject unit;
    public BuildingScriptableObject building;
}
