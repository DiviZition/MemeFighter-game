using UnityEngine;

public class PlayerDieFromFall : MonoBehaviour
{
    [SerializeField] private PlayerHealth _health;
    [SerializeField] private Transform _transform;

    [SerializeField] private float _hellDepth = 10;

    private void OnValidate()
    {
        _transform = this.gameObject.transform;
        _health = this.gameObject.GetComponent<PlayerHealth>();
    }

    private void FixedUpdate()
    {
        if (_transform.position.y < Mathf.Abs(_hellDepth) * -1)
            _health.TakeDamage(666);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine
            (Vector2.up * Mathf.Abs(_hellDepth) * -1 + Vector2.left * 100,
            (Vector2.up * Mathf.Abs(_hellDepth) * -1 + Vector2.right * 100));
    }
}