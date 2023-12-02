using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamagable
{
    [SerializeField] private SpriteRenderer _playersVisual;
    [SerializeField] private Color _dieColor;
    [SerializeField] private int _startHealth;
    [SerializeField] private float _damageCooldown;
    [SerializeField] private float _diyingSpeed;

    private Transform _transform;
    private Collider2D _collider;

    private Color _defaultColor;

    private float _damageTimer;
    private int _currentHealth;

    private bool _isHaveToDie = false;

    public int StartHealth => _startHealth;
    public int CurrentHealth => _currentHealth;
    private void Start()
    {
        _transform = this.gameObject.transform;
        _collider = this.gameObject.GetComponent<Collider2D>();
        _currentHealth = _startHealth;
        _defaultColor = _playersVisual.color;
    }

    private void FixedUpdate()
    {
        if (_isHaveToDie == true)
            Die();
        else
            _playersVisual.color = Color.Lerp(_playersVisual.color, _defaultColor, _diyingSpeed);
    }

    public void TakeDamage(int damage)
    {
        if (_damageTimer > Time.time)
            return;

        _damageTimer = Time.time + _damageCooldown;

        _playersVisual.color = _dieColor;

        if (_currentHealth - damage <= 0)
        {
            _isHaveToDie = true;
            return;
        }

        _currentHealth -= damage;
    }

    public void TakeHeal(int healAmount)
    {
        if (_currentHealth + healAmount > _startHealth)
        {
            _currentHealth = _startHealth;
            return;
        }

        _currentHealth += healAmount;
    }

    private void Die()
    {
        if(_collider.enabled == true)
        {
            _collider.attachedRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            _collider.enabled = false;
        }

        _transform.localScale = Vector3.MoveTowards(_transform.localScale, Vector3.zero, _diyingSpeed);

        if(_transform.localScale == Vector3.zero)
            Destroy(this.gameObject);
    }
}