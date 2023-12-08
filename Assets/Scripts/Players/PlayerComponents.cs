using UnityEngine;

public class PlayerComponents : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private Animator _animator;

    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private PlayerHealth _health;
    [SerializeField] private PlayerAttack _attack;
    [SerializeField] private PlayerPadTaker _padTaker;
    [SerializeField] private PlayerPadUsing _padUsing;

    [SerializeField] private PlayerAnimator _playerAnimator;

    public Transform Transform => _transform;
    public Rigidbody2D Rigidbody => _rigidbody;
    public Collider2D Collider => _collider;
    public Animator Animator => _animator;

    public PlayerMovement Movement => _movement;
    public PlayerHealth Health => _health;
    public PlayerAttack Attack => _attack;
    public PlayerPadTaker PadTaker => _padTaker;
    public PlayerPadUsing PadUsing => _padUsing;

    public PlayerAnimator PlayerAnimator => _playerAnimator;
}
