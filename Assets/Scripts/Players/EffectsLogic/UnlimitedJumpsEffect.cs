using System;
using UnityEngine;

[Serializable]
public struct UnlimitedJumpsEffect : IBoostEffect
{
    [SerializeField] private Sprite _effectsIcon;
    [SerializeField] private float _effectDuration;

    public Sprite EffectsIcon => _effectsIcon;
    public TypeOfEffect TypeOfEffect => TypeOfEffect.UnlimitedJumps;
    public bool IsEnded { get; private set; }
    public float Progress { get; private set; }

    public void DoLogic(PlayerComponents components)
    {
        Progress += Time.deltaTime / _effectDuration;

        if (components.Movement == null)
        {
            IsEnded = true;
            return;
        }

        components.Movement.ResetJumps();

        if(Progress > 1)
            IsEnded = true;
    }

    public void ForceQuit()
    {
        ResetValues();
    }

    public void ResetValues()
    {
        IsEnded = false;
        Progress = 0;
    }
}