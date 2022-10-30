using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBase : MonoBehaviour
{
    public BuildingScriptableObject buildingData;
    float maxHealth;

    float health;

    float attackDamage;

    float attackRate;

    float attackRange;

    float timeToNextAttack;

    Transform target;

    public bool isPlayer;

    private void Start()
    {
        maxHealth = buildingData.maxHealth;
        attackDamage = buildingData.attackDamage;
        attackRate = buildingData.attackRate;
        attackRange = buildingData.attackRange;

        health = maxHealth;
    }
}
