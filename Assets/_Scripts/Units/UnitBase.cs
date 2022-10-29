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

    bool attackMode;

    float moveSpeed;

    Transform enemyBase;

    Transform target;

    public bool isPlayer;

    string enemyTag;

    private void Start()
    {
        maxHealth = unitData.maxHealth;
        attackDamage = unitData.attackDamage;
        attackRate = unitData.attackRate;
        attackRange = unitData.attackRange;
        attackMode = unitData.attackMode;
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
        FindTarget();

        if (timeToNextAttack > 0) timeToNextAttack -= 1 * Time.deltaTime;
    }

    void FindTarget()
    {
        Collider[] objectsInRange =
            Physics.OverlapSphere(transform.position, attackRange);

        if(objectsInRange==null)
        return;

        List<Transform> targets = new();
        foreach (var item in objectsInRange)
        {
            if(item.GetComponent<UnitBase>())
            {
                if (isPlayer&&!item.GetComponent<UnitBase>().isPlayer)
                {
                  targets.Add(item.transform);
                }
                else if(!isPlayer&&item.GetComponent<UnitBase>().isPlayer)
                {
                    targets.Add(item.transform);
                }
            }
        }

        if (targets.Count ==0)
        {
            MoveToTarget (enemyBase);
            return;
        }

        target = FindClosestEnemy(targets).target;
        MoveToTarget (target);
    }

    public (Transform target, bool found)
    FindClosestEnemy(List<Transform> targets)
    {
        Transform closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

        foreach (Transform target in targets)
        {
            Vector3 diff = target.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = target;
                distance = curDistance;
            }
        }
        return (closest, true);
    }

    void MoveToTarget(Transform target)
    {
        transform.position =
            Vector3
                .MoveTowards(transform.position,
                target.position,
                moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) <= 1)
            Attack(target);
    }

    void Attack(Transform enemy)
    {
        if (timeToNextAttack <= 0)
        {
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
