using UnityEngine;

[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerHealth))]
[RequireComponent(typeof(PlayerAttack))]
[RequireComponent(typeof(PlayerPadTaker))]
[RequireComponent(typeof(PlayerPadUsing))]
public class PlayerComponents : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private PlayerHealth _health;
    [SerializeField] private PlayerAttack _attack;
    [SerializeField] private PlayerPadTaker _padTaker;
    [SerializeField] private PlayerPadUsing _padUsing;

    public Transform Transform => _transform;
    public Rigidbody2D Rigidbody => _rigidbody;
    public Collider2D Collider => _collider;
    public PlayerMovement Movement => _movement;
    public PlayerHealth Health => _health;
    public PlayerAttack Attack => _attack;
    public PlayerPadTaker PadTaker => _padTaker;
    public PlayerPadUsing PadUsing => _padUsing;
}
