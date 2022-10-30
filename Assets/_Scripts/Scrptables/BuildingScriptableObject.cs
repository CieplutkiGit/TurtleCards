using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[
    CreateAssetMenu(
        fileName = "CardScriptableObject",
        menuName = "ScriptableObjects/Building")
]
public class BuildingScriptableObject : ScriptableObject
{
    public float maxHealth;

    public float attackDamage;
    public float attackRate;

    public float attackRange;

    public GameObject buildPrefab;

}
