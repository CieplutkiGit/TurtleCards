using UnityEngine;
using UnityEngine.UI;

public class UnitBase : MonoBehaviour
{
    public UnitScriptableObject unitData;

    private float _maxHealth;

    private float _health;

    private float _attackDamage;

    private float _attackRate;

    private float _timeToNextAttack;

    private float _attackRange;

    private float _moveSpeed;

    private Transform _enemyBase;

    private Transform _target;

    public bool isPlayer;

    private Image _healthBar;

    private bool _isBuilding;

    private void Start()
    {
        _maxHealth = unitData.maxHealth;
        _attackDamage = unitData.attackDamage;
        _attackRate = unitData.attackRate;
        _attackRange = unitData.attackRange;
        _moveSpeed = unitData.moveSpeed;
        _enemyBase = unitData.enemyBase;
        _isBuilding = unitData.isBuilding;

        _health = _maxHealth;

        if (!isPlayer) _enemyBase = unitData.playerBase;

        _healthBar = GetComponentInChildren<Image>();
    }

    private void Update()
    {
        var target = FindTarget.GetTarget(transform, isPlayer, _attackRange);
        if (!_isBuilding)
        {
            if (target.hasTarget)
                MoveToTarget(target.transform);
            else
                MoveToTarget(_enemyBase);
        }
        else if (target.hasTarget) Attack(target.transform);

        if (_timeToNextAttack > 0) _timeToNextAttack -= 1 * Time.deltaTime;
    }

    void MoveToTarget(Transform target)
    {
        if (Vector3.Distance(transform.position, target.position) <=_attackRange)
            Attack(target);
        else
            transform.position =
                Vector3
                    .MoveTowards(transform.position,
                    target.position,
                    _moveSpeed * Time.deltaTime);
    }

    void Attack(Transform enemy)
    {
        if (_timeToNextAttack <= 0)
        {
            enemy.GetComponent<UnitBase>().TakeDamage(_attackDamage);
            _timeToNextAttack = _attackRate;
        }
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        UpdateHealthBar();
        if (_health <= 0) Die();
    }

    void UpdateHealthBar() => _healthBar.fillAmount = _health / _maxHealth;

    void Die() => Destroy(gameObject);
}
