using System;
using UnityEngine;

[Serializable]
public struct DefaultEffect : IBoostEffect
{
    [SerializeField] private Sprite _effectsIcon;

    public Sprite EffectsIcon => _effectsIcon;
    public TypeOfEffect TypeOfEffect => TypeOfEffect.Default;

    public bool IsEnded { get; private set; }

    public void DoLogic(Transform transform)
    {
        Debug.Log("FAILURE! Default effect was called");
        IsEnded = true;
    }

    public void ResetValues()
    {
        IsEnded = false;
    }
}
