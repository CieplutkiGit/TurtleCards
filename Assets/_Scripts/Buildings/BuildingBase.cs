using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    Image healthBar;

    private void Start()
    {
        maxHealth = buildingData.maxHealth;
        attackDamage = buildingData.attackDamage;
        attackRate = buildingData.attackRate;
        attackRange = buildingData.attackRange;

        health = maxHealth;

        healthBar = GetComponentInChildren<Image>();
    }

        public void TakeDamage(float damage)
    {
        health -= damage;
        UpdateHealthBar();
        if (health <= 0) Die();
    }

    void UpdateHealthBar()
    {
        healthBar.fillAmount = health / maxHealth;
    }
    void Die()
    {
        Destroy (gameObject);
        Debug.Log("baseDestroyed");
    }
}
