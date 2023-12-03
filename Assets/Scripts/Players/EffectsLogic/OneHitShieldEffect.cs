using System;
using UnityEngine;

[Serializable]
public struct OneHitShieldEffect : IBoostEffect
{
    [SerializeField] private Sprite _effectsIcon;
    [SerializeField] private float _effectDuration;

    private PlayerComponents _components;

    private bool _isFirstStepDone;

    public Sprite EffectsIcon => _effectsIcon;
    public TypeOfEffect TypeOfEffect => TypeOfEffect.OneHitShield;

    public bool IsEnded { get; private set; }
    public float Progress { get; private set; }

    public void DoLogic(PlayerComponents components)
    {
        Progress += Time.deltaTime / _effectDuration;

        if (_components == null)
            _components = components;

        if (_isFirstStepDone == false)
        {
            _isFirstStepDone = true;
            _components.Health.SetOneHitShield(true);
        }

        if (_components.Health.IsHaveHitProtection == false)
            IsEnded = true;

        if (Progress > 1)
        {
            _components.Health.SetOneHitShield(false);
            IsEnded = true;
        }
    }

    public void ForceQuit()
    {
        Progress = 1;
        DoLogic(_components);
    }

    public void ResetValues()
    {
        Progress = 0;
        IsEnded = false;
        _isFirstStepDone = false;
    }
}