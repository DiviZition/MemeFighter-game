using System;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class PlayerAnimator : MonoBehaviour
{
    private int _idleAnimationHash = Animator.StringToHash("PepeIdle");
    private int _runAnumationHash = Animator.StringToHash("PepeRun");
    private int _jumpAnimationHash = Animator.StringToHash("PepeJump");
    private int _attackAnimationHash = Animator.StringToHash("PepeAttack");
    private int _hurtAnimationHash = Animator.StringToHash("PepeHurt");

    private PlayerComponents _components;

    private int _currentAnimationHash;
    private float _animationLockTimer;
    private float _animationLockDuration = 0.1f;
    private float _defaultAnimatorSpeed;

    [Inject]
    private void Construct(PlayerComponents components)
    {
        _components = components;

        _defaultAnimatorSpeed = _components.Animator.speed;
    }

    public void Update()
    {
        _currentAnimationHash = GetCurrentAnimationHash();

        _components.Animator.speed = CurrentAnimatorSpeed();
        _components.Animator.CrossFade(_currentAnimationHash, 0);
    }

    private int GetCurrentAnimationHash()
    {
        _animationLockTimer += Time.deltaTime;
        if (_animationLockTimer < _animationLockDuration)
            return _currentAnimationHash;

        if (_components.Attack.IsAttacking == true)
            return LockAnimation(_attackAnimationHash, 0.1f);
        else if (_components.Health.IsInvincibleAfterHit == true)
            return LockAnimation(_hurtAnimationHash, 0.2f);
        else if (_components.Movement.IsGrounded == false)
            return _jumpAnimationHash;
        else if (_components.Rigidbody.velocity.x != 0)
            return _runAnumationHash; 
        else
            return _idleAnimationHash;
    }

    private int LockAnimation(int animationHash, float lockDuration)
    {
        _animationLockTimer = 0;
        _animationLockDuration = lockDuration;

        return animationHash;
    }

    private float CurrentAnimatorSpeed()
    {
        if (_currentAnimationHash == _runAnumationHash)
            return _components.Movement.CurrentSpeed / _components.Movement.DefaultSpeed;
        else
            return _defaultAnimatorSpeed;
    }
}
