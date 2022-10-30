using UnityEngine;
[
    CreateAssetMenu(
        fileName = "CardScriptableObject",
        menuName = "ScriptableObjects/Card")
]
public class CardScriptableObject : ScriptableObject
{
    public string cardName;

    public int cardID;

    public Sprite cardSplashArt;

    public UnitScriptableObject unit;
}
