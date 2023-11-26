using UnityEngine;

public class PadTaker : MonoBehaviour
{
    [SerializeField] private Vector2 _takerOffsetPosition;
    [SerializeField] private Transform _transform;
    [SerializeField] private LayerMask _effectsLayer;
    [SerializeField] private float _radiusTakeZone;

    public bool IsHasBoost { get; private set; } = false;
    public TypeOfEffect EffectType { get; private set; } = TypeOfEffect.DefaultEffect;

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
        EffectType = TypeOfEffect.DefaultEffect;
        IsHasBoost = false;
    }
}
