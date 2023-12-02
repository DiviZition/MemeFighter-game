using System;
using UnityEngine;

[Serializable]
public struct HealEffect : IBoostEffect
{
    [SerializeField] private Sprite _effectsIcon;
    [SerializeField] private int _healAmount;

    public Sprite EffectsIcon => _effectsIcon;

    public TypeOfEffect TypeOfEffect => TypeOfEffect.Heal;

    public bool IsEnded { get; private set; }

    public float Progress => 1;

    public void DoLogic(PlayerComponents components)
    {
        components.Health.TakeHeal(_healAmount);
        IsEnded = true;
    }

    public void ResetValues()
    {
        IsEnded = false;
    }
}