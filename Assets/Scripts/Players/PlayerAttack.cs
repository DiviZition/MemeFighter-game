﻿using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private int _startDamage;
    [SerializeField] private Vector2 _attackPosition;
    [SerializeField] private float _attackRadius;
    [SerializeField] private float _defaultAttackDuration;
    [SerializeField] private LayerMask _playerMask;

    private Transform _transform;
    private IEnumerator _attackCotoutine;
    private float _attackTimer;
    private int _currentDamage;

    public float DefaultAttackDuration => _defaultAttackDuration;
    public float AttackDuration { get; private set; }
    public bool IsAttacking { get; private set; }
    public int CurrentDamage => _currentDamage;
    public int StartDamage => _startDamage;

    private void Start()
    {
        _transform = this.GetComponent<Transform>();
        _attackCotoutine = AttackLogic();
        AttackDuration = _defaultAttackDuration;
    }

    private void Update()
    {
        DoAttack();
    }

    private void DoAttack()
    {
        if (Input.GetKeyDown(ControllsConfig.Attack) && _attackTimer < Time.time)
        {
            _attackTimer = Time.time + AttackDuration;
            _attackCotoutine = AttackLogic();
            StartCoroutine(_attackCotoutine);
        }
    }

    private IEnumerator AttackLogic()
    {
        Collider2D overlappedCollider = Physics2D.OverlapCircle
            ((Vector2)_transform.position + _attackPosition * Mathf.Sign(_transform.localScale.x),
            _attackRadius, _playerMask);

        if (overlappedCollider != null)
        {
            overlappedCollider.gameObject.GetComponent<IDamagable>().TakeDamage(_currentDamage);
        }

        IsAttacking = true;

        yield return new WaitForSeconds(AttackDuration);
        
        IsAttacking = false;

        StopCoroutine(_attackCotoutine);
    }

    public void ChangeDamage(int newDamage) => _currentDamage = newDamage;
    public void ChangeAttackCoolDown(float newDamageCoolDown) => AttackDuration = newDamageCoolDown;

    private void OnDrawGizmos()
    {
        if (_transform == null)
            return;

        Gizmos.DrawSphere(
            (Vector2)_transform.position + _attackPosition * Mathf.Sign(_transform.localScale.x), 
            _attackRadius);
    }
}
