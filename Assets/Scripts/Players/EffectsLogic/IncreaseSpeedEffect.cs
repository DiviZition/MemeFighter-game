using System;
using UnityEngine;

[Serializable]
public struct IncreaseSpeedEffect : IBoostEffect
{
    [SerializeField] private Sprite _effectIcon;
    [SerializeField] private float _effectDuration;
    [SerializeField] private float _additionalSpeed;

    private PlayerComponents _components;

    private bool _isFirstStepDone;

    public Sprite EffectsIcon => _effectIcon;
    public TypeOfEffect TypeOfEffect => TypeOfEffect.IncreaseSpeed;

    public bool IsEnded { get; private set; }
    public float Progress { get; private set; }

    public void DoLogic(PlayerComponents components)
    {
        Progress += Time.deltaTime / _effectDuration;

        if (_components == null)
            _components = components;

        if (Progress > 1)
        {
            _components.Movement.ChangeSpeed
                (_components.Movement.CurrentSpeed - Mathf.Abs(_additionalSpeed));
            IsEnded = true;
            return;
        }

        if (_isFirstStepDone == true)
            return;

        _isFirstStepDone = true;
        _components.Movement.ChangeSpeed
            (_components.Movement.CurrentSpeed + Mathf.Abs(_additionalSpeed));
    }

    public void ResetValues()
    {
        IsEnded = false;
        _isFirstStepDone = false;
        Progress = 0;
    }

    public void ForceQuit()
    {
        Progress = 1;
        DoLogic(_components);
    }
}
