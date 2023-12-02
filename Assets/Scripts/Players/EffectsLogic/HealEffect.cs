using System;
using UnityEngine;

[Serializable]
public struct HealEffect : IBoostEffect
{
    [SerializeField] private Sprite _effectsIcon;
    [SerializeField] private int _healAmount;

    public Sprite EffectsIcon => _effectsIcon;

    public TypeOfEffect TypeOfEffect => TypeOfEffect.HealPlayer;

    public bool IsEnded { get; private set; }

    public float Progress => 1;

    public void DoLogic(Transform transform)
    {
        transform.GetComponent<PlayerHealth>().TakeHeal(_healAmount);
        IsEnded = true;
    }

    public void ResetValues()
    {
        IsEnded = false;
    }
}