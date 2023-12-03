using System;
using UnityEngine;

[Serializable]
public struct DoubleDamageEffect : IBoostEffect
{
    [SerializeField] private Sprite _effectsIcon;
    [SerializeField] private float _effectDuration;

    private PlayerComponents _components;

    private bool _isFirstStepDone;
    private int _damageAdded;

    public Sprite EffectsIcon => _effectsIcon;
    public TypeOfEffect TypeOfEffect => TypeOfEffect.DoubleDamage;

    public bool IsEnded { get; private set; }
    public float Progress { get; private set; }

    public void DoLogic(PlayerComponents components)
    {
        Progress += Time.deltaTime / _effectDuration;

        if(_components == null)
            _components = components;

        if (Progress > 1)
        {
            _components.Attack.ChangeDamage(_components.Attack.CurrentDamage - _damageAdded);
            IsEnded = true;
        }

        if (_isFirstStepDone == true)
            return;

        _isFirstStepDone = true;
        _damageAdded = Mathf.CeilToInt(_components.Attack.CurrentDamage);
        _components.Attack.ChangeDamage(_components.Attack.CurrentDamage + _damageAdded);
    }

    public void ResetValues()
    {
        _isFirstStepDone = false;
        IsEnded = false;
        _damageAdded = 0;
        Progress = 0;
    }

    public void ForceQuit() 
    {
        Progress = 1;
        DoLogic(_components);
    }
}