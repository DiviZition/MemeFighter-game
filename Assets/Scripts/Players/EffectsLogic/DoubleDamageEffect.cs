using System;
using UnityEngine;

[Serializable]
public struct DoubleDamageEffect : IBoostEffect
{
    [SerializeField] private Sprite _effectsIcon;
    [SerializeField] private float _effectDuration;
    public Sprite EffectsIcon => _effectsIcon;
    public TypeOfEffect TypeOfEffect => TypeOfEffect.DoubleDamage;

    public bool IsEnded { get; private set; }
    public float Progress { get; private set; }

    private PlayerAttack _playerAttack;

    private bool _isFirstStepDone;
    private int _damageAdded;

    public void DoLogic(Transform transform)
    {
        Progress += Time.deltaTime / _effectDuration;

        if (Progress > 1)
        {
            _playerAttack.ChangeDamage(_playerAttack.CurrentDamage - _damageAdded);
            IsEnded = true;
        }

        if (_isFirstStepDone == true)
            return;

        _isFirstStepDone = true;
        _playerAttack = transform.GetComponent<PlayerAttack>();
        _damageAdded = Mathf.CeilToInt(_playerAttack.CurrentDamage);
        _playerAttack.ChangeDamage(_playerAttack.CurrentDamage + _damageAdded);
        Debug.Log(_damageAdded);
    }

    public void ResetValues()
    {
        _playerAttack = null;
        _isFirstStepDone = false;
        IsEnded = false;
        _damageAdded = 0;
        Progress = 0;
    }
}