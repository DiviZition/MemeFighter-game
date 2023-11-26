using System;
using UnityEngine;

[Serializable]
public struct NewEffect : IBoostEffect
{
    public Sprite EffectsIcon => throw new NotImplementedException();
    public TypeOfEffect TypeOfEffect => throw new NotImplementedException();

    public bool IsEnded => throw new NotImplementedException();


    public void DoLogic(Transform transform)
    {
        throw new NotImplementedException();
    }

    public void ResetValues()
    {
        throw new NotImplementedException();
    }
}