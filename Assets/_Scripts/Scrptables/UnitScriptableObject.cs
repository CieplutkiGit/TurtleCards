using UnityEngine;

[
    CreateAssetMenu(
        fileName = "CardScriptableObject",
        menuName = "ScriptableObjects/Unit")
]
public class UnitScriptableObject : ScriptableObject
{
    public float maxHealth;

    public float attackDamage;

    public float attackRate;

    public float attackRange;

    public float moveSpeed;

    public Transform enemyBase;

    public Transform playerBase;

    public GameObject unitPrefab;

    public bool isBuilding;
}
