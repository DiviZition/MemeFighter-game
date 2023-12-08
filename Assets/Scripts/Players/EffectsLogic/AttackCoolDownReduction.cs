using System;
using UnityEngine;

[Serializable]
public struct AttackCoolDownReduction : IBoostEffect
{
    [SerializeField] private Sprite _effectIcon;
    [SerializeField] private float _effectDuration;
    [Range (0, 1)][SerializeField] private float _attackCoolDownReduction;

    private PlayerComponents _components;

    private bool _isFirstIterationDone;
    private float _takenDuration;

    public Sprite EffectsIcon => _effectIcon;
    public TypeOfEffect TypeOfEffect => TypeOfEffect.AttackCoolDownReduction;

    public bool IsEnded { get; private set; }
    public float Progress { get; private set; }

    public void DoLogic(PlayerComponents components)
    {
        Progress += Time.deltaTime / _effectDuration;

        if (Progress > 1)
        {
            components.Attack.ChangeAttackCoolDown(components.Attack.AttackDuration + _takenDuration);
            IsEnded = true;
        }

        if (_isFirstIterationDone == true)
            return;

        _isFirstIterationDone = true;
        _components = components;
        _takenDuration = components.Attack.DefaultAttackDuration * _attackCoolDownReduction;
        components.Attack.ChangeAttackCoolDown
            (components.Attack.DefaultAttackDuration - _takenDuration);
    }

    public void ForceQuit()
    {
        Progress = 1;
        DoLogic(_components);
    }

    public void ResetValues()
    {
        _isFirstIterationDone = false;
        Progress = 0;
        IsEnded = false;
        _components = null;
        _takenDuration = 0;
    }
}