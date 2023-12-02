using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private int _startDamage;
    [SerializeField] private SpriteRenderer _fist;
    [SerializeField] private bool _isLeftPartOfKeyboard;
    [SerializeField] private Vector2 _attackPosition;
    [SerializeField] private float _attackRadius;
    [SerializeField] private float _attackDuration;
    [SerializeField] private LayerMask _playerMask;

    private Transform _transform;
    private IEnumerator _attackCotoutine;
    private float _attackTimer;
    private int _currentDamage;

    public int CurrentDamage => _currentDamage;
    public int StartDamage => _startDamage;
    private void Start()
    {
        _transform = this.gameObject.transform;
        _attackCotoutine = DoAttack();
    }

    private void Update()
    {
        if (_isLeftPartOfKeyboard == true)
            DoAttack(KeyCode.Space);
        else if (_isLeftPartOfKeyboard == false)
            DoAttack(KeyCode.KeypadEnter);

    }

    private void DoAttack(KeyCode attackButton)
    {
        if (Input.GetKeyDown(attackButton) && _attackTimer < Time.time)
        {
            _attackTimer = Time.time + _attackDuration;
            _attackCotoutine = DoAttack();
            StartCoroutine(_attackCotoutine);
        }
    }

    private IEnumerator DoAttack()
    {
        Collider2D overlappedCollider = Physics2D.OverlapCircle
            ((Vector2)_transform.position + _attackPosition * Mathf.Sign(_transform.localScale.x),
            _attackRadius, _playerMask);

        if (overlappedCollider != null)
        {
            overlappedCollider.gameObject.GetComponent<IDamagable>().TakeDamage(_currentDamage);
        }

        _fist.enabled = true;

        yield return new WaitForSeconds(_attackDuration);

        _fist.enabled = false;

        StopCoroutine(_attackCotoutine);
    }

    public void ChangeDamage(int newDamage) => _currentDamage = newDamage;

    private void OnDrawGizmos()
    {
        if (_transform == null)
            return;

        Gizmos.DrawSphere(
            (Vector2)_transform.position + _attackPosition * Mathf.Sign(_transform.localScale.x), 
            _attackRadius);
    }
}
