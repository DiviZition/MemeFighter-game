using UnityEngine;
using Zenject;

public class PlayerPadTaker : MonoBehaviour
{
    [SerializeField] private Vector2 _takerOffsetPosition;
    [SerializeField] private LayerMask _effectsLayer;
    [SerializeField] private float _radiusTakeZone;

    private Transform _transform;
    public bool IsHasBoost { get; private set; } = false;
    public TypeOfEffect EffectType { get; private set; } = TypeOfEffect.Default;

    [Inject]
    private void Construct(PlayerComponents components)
    {
        _transform = components.Transform;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && IsHasBoost == false)
        {
            Collider2D foundPad;

            foundPad = Physics2D.OverlapCircle
                ((Vector2)_transform.position +
                (_takerOffsetPosition * new Vector2(_transform.localScale.x, 1)),
                _radiusTakeZone, _effectsLayer);

            if (foundPad != null)
            {
                EffectType = foundPad.GetComponent<EffectPad>().EffectType;
                Debug.Log(EffectType);

                Destroy(foundPad.gameObject);
                IsHasBoost = true;
            }

        }
    }

    public void ResetEffect()
    {
        EffectType = TypeOfEffect.Default;
        IsHasBoost = false;
    }
}
