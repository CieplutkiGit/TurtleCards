using System.Collections.Generic;
using UnityEngine;

public class UnitBase : MonoBehaviour
{
    public UnitScriptableObject unitData;

    float maxHealth;

    float health;

    float attackDamage;

    float attackRate;

    float timeToNextAttack;

    float attackRange;

    float moveSpeed;

    Transform enemyBase;

    Transform target;

    public bool isPlayer;

    private void Start()
    {
        maxHealth = unitData.maxHealth;
        attackDamage = unitData.attackDamage;
        attackRate = unitData.attackRate;
        attackRange = unitData.attackRange;
        moveSpeed = unitData.moveSpeed;
        enemyBase = unitData.enemyBase;

        health = maxHealth;

        if (!isPlayer)
        {
            enemyBase = unitData.playerBase;
        }
    }

    private void Update()
    {
        var target = FindTarget.GetTarget(transform, isPlayer,attackRange);
        if(target.hasTarget)
            MoveToTarget(target.target);
            else
            MoveToTarget(enemyBase);
        if (timeToNextAttack > 0) timeToNextAttack -= 1 * Time.deltaTime;
    }

    void MoveToTarget(Transform target)
    {
        
        if (Vector3.Distance(transform.position, target.position) <= attackRange)
            Attack(target);
            else
            transform.position =
            Vector3
                .MoveTowards(transform.position,
                target.position,
                moveSpeed * Time.deltaTime);

    }

    void Attack(Transform enemy)
    {
        if (timeToNextAttack <= 0)
        {
            if(enemy.GetComponent<UnitBase>())
            enemy.GetComponent<UnitBase>().TakeDamage(attackDamage);
            timeToNextAttack = attackRate;
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0) Die();
    }

    void Die()
    {
        Destroy (gameObject);
        Debug.Log(":<");
    }
}
