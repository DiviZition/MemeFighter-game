using System;
using UnityEngine;

[Serializable]
public struct OneHitShieldEffect : IBoostEffect
{
    [SerializeField] private Sprite _effectsIcon;
    [SerializeField] private float _effectDuration;

    public Sprite EffectsIcon => _effectsIcon;

    public TypeOfEffect TypeOfEffect => TypeOfEffect.OneHitShield;

    public bool IsEnded { get; private set; }

    public float Progress { get; private set; }

    public void DoLogic(Transform transform)
    {
    }

    public void ResetValues()
    {
    }
}