using UnityEngine;
using VContainer;

public class PlayerHealth : MonoBehaviour, IDamagable
{
    [SerializeField] private SpriteRenderer _playersVisual;
    [SerializeField] private Color _hurtColor;
    [SerializeField] private int _startHealth;
    [SerializeField] private float _damageCooldown;
    [SerializeField] private float _diyingSpeed;

    private PlayerComponents _components;

    private Color _defaultColor;

    private float _damageTimer;
    private int _currentHealth;
    private bool _isHaveToDie = false;

    public bool IsHaveDeathProtection { get; private set; }
    public bool IsHaveHitProtection { get; private set; }

    public int StartHealth => _startHealth;
    public int CurrentHealth => _currentHealth;

    public bool IsInvincibleAfterHit => _damageTimer < _damageCooldown;

    [Inject]
    private void Construct(PlayerComponents components)
    {
        _components = components;

        _currentHealth = _startHealth;
        _defaultColor = _playersVisual.color;

        _damageTimer = _damageCooldown;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            TakeDamage(1);
    }

    private void FixedUpdate()
    {
        _damageTimer += Time.deltaTime;

        if (_isHaveToDie == true)
            Die();
        else
            _playersVisual.color = Color.Lerp(_playersVisual.color, _defaultColor, _diyingSpeed);
    }

    public void TakeDamage(int damage)
    {
        if (_damageTimer < _damageCooldown)
            return;

        if (IsHaveHitProtection == true)
        {
            IsHaveHitProtection = false;
            return;
        }

        _damageTimer = 0;
        GetHit(damage);
    }

    private void GetHit(int damage)
    {
        _playersVisual.color = _hurtColor;

        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            if (IsHaveDeathProtection == true)
            {
                IsHaveDeathProtection = false;
                _currentHealth = 1;
            }
            else
            {
                _isHaveToDie = true;
            }
        }
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

    public void SetOneHitShield(bool isEnabled) => IsHaveHitProtection = isEnabled;
    public void SetDeathProtection(bool isEnabled) => IsHaveDeathProtection = isEnabled;

    private void Die()
    {
        if(_components.Collider.enabled == true)
        {
            _components.Collider.attachedRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            _components.Collider.enabled = false;
        }

        _components.Transform.localScale = Vector3.MoveTowards
            (_components.Transform.localScale, Vector3.zero, _diyingSpeed);

        if (_components.Transform.localScale == Vector3.zero)
            MonoBehaviour.Destroy(_components.gameObject);
    }
}