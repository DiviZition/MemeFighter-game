using UnityEngine;
using Zenject;

public class PlayerPadUsing : MonoBehaviour
{
    private PlayerComponents _components;

    public IBoostEffect EquippedEffect { get; private set; }
    public float ActieveEffectProgress { get; private set; }

    [Inject]
    private void Construct(PlayerComponents components)
    {
        _components = components;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && EquippedEffect == null)
        {
            if (_components.PadTaker.EffectType == TypeOfEffect.Default)
                return;

            EquippedEffect = EffectsStorage.GetEffect(_components.PadTaker.EffectType);
            _components.PadTaker.ResetEffect();
        }

        if (EquippedEffect == null)
            return;

        EquippedEffect.DoLogic(_components);
        ActieveEffectProgress = EquippedEffect.Progress;
        
        if (EquippedEffect.IsEnded == true)
        {
            EquippedEffect.ResetValues();
            ActieveEffectProgress = 0;
            EquippedEffect = null;
            return;
        }
    }
}
