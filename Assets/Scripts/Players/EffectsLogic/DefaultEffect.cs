﻿using System;
using UnityEngine;

[Serializable]
public struct DefaultEffect : IBoostEffect
{
    [SerializeField] private Sprite _effectsIcon;

    public Sprite EffectsIcon => _effectsIcon;
    public TypeOfEffect TypeOfEffect => TypeOfEffect.Default;

    public bool IsEnded { get; private set; }

    public float Progress => 1;

    public void DoLogic(PlayerComponents components)
    {
        Debug.Log("FAILURE! Default effect was called");
        IsEnded = true;
    }

    public void ForceQuit() { }

    public void ResetValues()
    {
        IsEnded = false;
    }
}
