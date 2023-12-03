using UnityEngine;
using Zenject;

public class PlayerPadUsing : MonoBehaviour
{
    private PlayerComponents _components;

    public IBoostEffect ActieveEffect { get; private set; }
    public float ActieveEffectProgress { get; private set; }

    [Inject]
    private void Construct(PlayerComponents components)
    {
        _components = components;
    }

    void Update()
    {
        ActivateEffect();

        if (ActieveEffect == null)
            return;

        ActieveEffect.DoLogic(_components);
        ActieveEffectProgress = ActieveEffect.Progress;

        if (ActieveEffect.IsEnded == true)
            ClearActieveEffect();
    }

    private void ActivateEffect()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (_components.PadTaker.EffectType == TypeOfEffect.Default)
                return;

            ClearActieveEffect();
            ActieveEffect = EffectsStorage.GetEffect(_components.PadTaker.EffectType);
            _components.PadTaker.ResetEffect();
        }
    }

    private void ClearActieveEffect()
    {
        if (ActieveEffect == null)
            return;

        ActieveEffect.ForceQuit();
        ActieveEffect.ResetValues();
        ActieveEffectProgress = 0;
        ActieveEffect = null;
    }
}
