using UnityEngine;

public class EffectPadSelfDestroyer : MonoBehaviour
{
    [SerializeField] private Collider2D _collider;
    [SerializeField] private SpriteRenderer _renderer;

    [SerializeField] private float _lifeDuration;
    [Range(0, 1)][SerializeField] private float _startsBlinkingAfter;
    [SerializeField] private float _blinkingSpeed;

    private Color _startColor;

    private float _lifeTimer = 0;
    private float _blinkPrecess = 0;

    private void Start()
    {
        _collider = this.GetComponent<Collider2D>();
        _startColor = _renderer.color;
    }

    private void FixedUpdate()
    {
        if (_collider.enabled == false)
            return;

        _lifeTimer += Time.deltaTime / _lifeDuration;

        if (_lifeTimer > _startsBlinkingAfter)
            BlinkVisula();

        if (_lifeTimer > 1)
            DestroyEffectPad();
    }

    private void BlinkVisula()
    {
        _blinkPrecess += Time.deltaTime;

        _renderer.color = new Color(_renderer.color.r, _renderer.color.g, _renderer.color.b,
            (Mathf.Cos(_blinkPrecess * _blinkingSpeed) + 1) / 2); 
        //Cos is (-1, 1), but we need (0, 1). So +1 for beeng (0, 2) and / 2 for beeng (0, 1).
    }

    private void DestroyEffectPad()
    {
        Destroy(this.gameObject);
    }
}
