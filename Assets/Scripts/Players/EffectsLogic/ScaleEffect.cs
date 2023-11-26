using System;
using UnityEngine;

[Serializable]
public struct ScaleEffect : IBoostEffect
{
    [SerializeField] private Sprite _effectsIcon; 
    [SerializeField] private float _scaleMultyplier;
    [SerializeField] private float _duration;

    private Transform _transform;

    private float _addedScale;
    private float _effectDurationTimer;
    private bool _isLogicWasCompleted;

    public bool IsEnded { get; private set; }
    public TypeOfEffect TypeOfEffect => TypeOfEffect.ScaleEffect;

    public Sprite EffectsIcon => _effectsIcon;

    public void ResetValues()
    {
        _addedScale = 0;
        _effectDurationTimer = 0;
        _isLogicWasCompleted = false;
        IsEnded = false;
        _transform = null;
    }


    public void DoLogic(Transform transform)
    {
        _effectDurationTimer += Time.deltaTime;
        if (_effectDurationTimer > _duration)
        {
            ScaleTransform(false);
            IsEnded = true;
        }

        if (_isLogicWasCompleted == true)
            return;

        _isLogicWasCompleted = true;
        SetupStartValues(transform);

        ScaleTransform(true);
    }

    private void SetupStartValues(Transform transform)
    {
        _transform = transform;

        float scale = (Mathf.Abs(_transform.localScale.x) + Mathf.Abs(_transform.localScale.y) / 2);
        _addedScale = scale * _scaleMultyplier;
        _addedScale -= scale;
    }

    private void ScaleTransform(bool isEnlarged)
    {
        sbyte sign;
        if (isEnlarged == true)
            sign = 1;
        else
            sign = -1;

        _transform.localScale = new Vector3
            (_transform.localScale.x + (_addedScale * sign * Mathf.Sign(_transform.localScale.x)),
            _transform.localScale.y + (_addedScale * sign * Mathf.Sign(_transform.localScale.y)),
            _transform.localScale.z);
    }
}
