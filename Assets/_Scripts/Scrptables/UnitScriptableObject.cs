using System.Collections;
using System.Collections.Generic;
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

    public float attackRange;

    public GameObject unitPrefab;

}
