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

    public float maxHealth;

    public float attackDamage;

    public float attackRange;

    public Sprite cardSplashArt;

    public GameObject unitPrefab; //to do przeniesc floaty do nowego scriptable obiekta ktory bedzie tu przypisany i zniego spawnowac
}
