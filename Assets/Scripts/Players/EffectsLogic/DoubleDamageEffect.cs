using System;
using UnityEngine;

[Serializable]
public struct DoubleDamageEffect : IBoostEffect
{
    [SerializeField] private Sprite _effectsIcon;
    [SerializeField] private float _effectDuration;
    public Sprite EffectsIcon => _effectsIcon;
    public TypeOfEffect TypeOfEffect => TypeOfEffect.DoubleDamage;

    public bool IsEnded { get; private set; }
    public float Progress { get; private set; }

    private bool _isFirstStepDone;
    private int _damageAdded;

    public void DoLogic(PlayerComponents components)
    {
        Progress += Time.deltaTime / _effectDuration;

        if (Progress > 1)
        {
            components.Attack.ChangeDamage(components.Attack.CurrentDamage - _damageAdded);
            IsEnded = true;
        }

        if (_isFirstStepDone == true)
            return;

        _isFirstStepDone = true;
        _damageAdded = Mathf.CeilToInt(components.Attack.CurrentDamage);
        components.Attack.ChangeDamage(components.Attack.CurrentDamage + _damageAdded);
        Debug.Log(_damageAdded);
    }

    public void ResetValues()
    {
        _isFirstStepDone = false;
        IsEnded = false;
        _damageAdded = 0;
        Progress = 0;
    }
}