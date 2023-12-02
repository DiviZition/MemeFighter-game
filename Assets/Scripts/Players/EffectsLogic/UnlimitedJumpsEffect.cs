using System;
using UnityEngine;

[Serializable]
public struct UnlimitedJumpsEffect : IBoostEffect
{
    [SerializeField] private Sprite _effectsIcon;
    [SerializeField] private float _effectDuration;

    private PlayerController _controller;

    private float _durationTimer;
    private bool _isFirstStepDone;

    public Sprite EffectsIcon => _effectsIcon;
    public TypeOfEffect TypeOfEffect => TypeOfEffect.UnlimitedJumps;
    public bool IsEnded { get; private set; }


    public void DoLogic(Transform transform)
    {
        if(_isFirstStepDone == false)
        {
            _isFirstStepDone = true;
            _durationTimer = Time.time + _effectDuration;
            _controller = transform.GetComponent<PlayerController>();
        }

        if (_controller == null)
        {
            IsEnded = true;
            return;
        }

        _controller.ResetJumps();

        if(_durationTimer < Time.time)
            IsEnded = true;
    }

    public void ResetValues()
    {
        _isFirstStepDone = false;
        IsEnded = false;
        _durationTimer = 0;
        _controller = null;
    }
}