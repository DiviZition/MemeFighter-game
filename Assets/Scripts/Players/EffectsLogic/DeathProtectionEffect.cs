using System;
using UnityEngine;

[Serializable]
public struct DeathProtectionEffect : IBoostEffect
{
    public Sprite EffectsIcon => throw new NotImplementedException();

    public TypeOfEffect TypeOfEffect => throw new NotImplementedException();

    public bool IsEnded => throw new NotImplementedException();

    public float Progress => throw new NotImplementedException();

    public void DoLogic(PlayerComponents components)
    {
        throw new NotImplementedException();
    }

    public void ResetValues()
    {
        throw new NotImplementedException();
    }
}