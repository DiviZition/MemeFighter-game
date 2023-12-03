using System;
using UnityEngine;

[Serializable]
public struct DeathProtectionEffect : IBoostEffect
{
    [SerializeField] private Sprite _effectsIcon;

    public Sprite EffectsIcon => _effectsIcon;
    public TypeOfEffect TypeOfEffect => TypeOfEffect.DeathProtection;

    public bool IsEnded { get; private set; }
    public float Progress => 1;

    public void DoLogic(PlayerComponents components)
    {
        components.Health.SetDeathProtection(true);
        IsEnded = true;
    }

    public void ForceQuit() { }

    public void ResetValues()
    {
        IsEnded = false;
    }
}