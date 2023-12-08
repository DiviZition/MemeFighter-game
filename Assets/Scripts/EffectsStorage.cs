using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EffectsStorage : MonoBehaviour
{
    [SerializeField] private DefaultEffect _defaultEffect;
    [SerializeField] private UnlimitedJumpsEffect _unlimitedJumpsEffect;
    [SerializeField] private DoubleDamageEffect _doubleDamageEffect;
    [SerializeField] private IncreaseSpeedEffect _increaseSpeedEffect;
    [SerializeField] private HealEffect _healEffect;
    [SerializeField] private OneHitShieldEffect _oneHitShieldEffect;
    [SerializeField] private DeathProtectionEffect _deathProtectionEffect;
    [SerializeField] private AttackCoolDownReduction _attackCoolDownReduction;

    public static List<IBoostEffect> Effects { get; private set; } = new List<IBoostEffect>(8);

    private void Start()
    {
        Effects.Add(_defaultEffect);
        Effects.Add(_unlimitedJumpsEffect);
        Effects.Add(_doubleDamageEffect);
        Effects.Add(_increaseSpeedEffect);
        Effects.Add(_healEffect);
        Effects.Add(_oneHitShieldEffect);
        Effects.Add(_deathProtectionEffect);
        Effects.Add(_attackCoolDownReduction);
    }

    public static IBoostEffect GetEffect(TypeOfEffect type)
    {
        for (int i = 0; i < Effects.Count; i++)
        {
            if (Effects[i].TypeOfEffect == type)
                return Effects[i];
        }

        return Effects[0];
    }
}

public enum TypeOfEffect
{
    Default = 0,
    UnlimitedJumps = 1,
    DoubleDamage = 2, 
    IncreaseSpeed = 3,
    Heal = 4,
    OneHitShield = 5,
    DeathProtection = 6,
    AttackCoolDownReduction = 7,
}
