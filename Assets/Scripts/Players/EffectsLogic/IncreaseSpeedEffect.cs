using System;
using UnityEngine;

[Serializable]
public struct IncreaseSpeedEffect : IBoostEffect
{
    [SerializeField] private Sprite _effectIcon;
    [SerializeField] private float _effectDuration;
    [SerializeField] private float _additionalSpeed;

    public Sprite EffectsIcon => _effectIcon;
    public TypeOfEffect TypeOfEffect => TypeOfEffect.IncreaseSpeed;

    public bool IsEnded { get; private set; }
    public float Progress { get; private set; }

    private PlayerController _controller;
    private bool _isFirstStepDone;

    public void DoLogic(Transform transform)
    {
        Progress += Time.deltaTime / _effectDuration;
        if (Progress > 1)
        {
            _controller.ChangeSpeed(_controller.CurrentSpeed - Mathf.Abs(_additionalSpeed));
            IsEnded = true;
            return;
        }

        if (_isFirstStepDone == true)
            return;

        _isFirstStepDone = true;
        _controller = transform.GetComponent<PlayerController>();
        _controller.ChangeSpeed(_controller.CurrentSpeed + Mathf.Abs(_additionalSpeed));
    }

    public void ResetValues()
    {
        IsEnded = false;
        _isFirstStepDone = false;
        Progress = 0;
        _controller = null;
    }
}
