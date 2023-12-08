using UnityEngine;
using VContainer;

public class PlayerDieFromFall : MonoBehaviour
{
    [SerializeField] private float _hellDepth = 10;

    private PlayerComponents _components;
    
    [Inject]
    private void Construct(PlayerComponents components)
    {
        _components = components;
    }
    
    private void FixedUpdate()
    {
        if (_components == null)
            return;

        if (_components.Transform.position.y < Mathf.Abs(_hellDepth) * -1)
            _components.Health.TakeDamage(666);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine
            (Vector2.up * Mathf.Abs(_hellDepth) * -1 + Vector2.left * 100,
            (Vector2.up * Mathf.Abs(_hellDepth) * -1 + Vector2.right * 100));
    }
}