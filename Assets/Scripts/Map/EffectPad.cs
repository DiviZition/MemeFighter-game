using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPad : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _fallingSpeed;
    public TypeOfEffect EffectType { get; set; }

    public void SetEffectType(TypeOfEffect type)
    {
        EffectType = type;
        _spriteRenderer.sprite = EffectsStorage.GetEffect(type).EffectsIcon;
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = Vector2.up * Mathf.Abs(_fallingSpeed) * -1;
    }
}
