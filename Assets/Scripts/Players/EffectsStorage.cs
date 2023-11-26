using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EffectsStorage : MonoBehaviour
{
    [SerializeField] private DefaultEffect _defaultEffect;
    [SerializeField] private ScaleEffect _scaleEffect;
    [SerializeField] private UnlimitedJumpsEffect _unlimitedJumpsEffect;

    public static List<IBoostEffect> Effects { get; private set; } = new List<IBoostEffect>(8);

    private void Start()
    {
        Effects.Add(_defaultEffect);
        Effects.Add(_scaleEffect);
        Effects.Add(_unlimitedJumpsEffect);
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
    DefaultEffect,
    ScaleEffect,
    UnlimitedJumpsEffect,

}
