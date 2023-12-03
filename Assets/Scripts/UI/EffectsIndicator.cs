using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class EffectsIndicator : MonoBehaviour
{
    [SerializeField] private Image _effectInPocketIcon;
    [SerializeField] private Image _effectInUseIcon;
    [SerializeField] private Image _effectProgress;

    private TypeOfEffect _effectInPocketType;
    private TypeOfEffect _effectInUseType;

    private PlayerComponents _components;

    [Inject]
    private void Construct(PlayerComponents components)
    {
        _components = components;
    }

    private void FixedUpdate()
    {
        SetupEffectInPocket();
        SetupActieveEffect();
        UpdateActieveEffectsProgress();
    }

    private void SetupEffectInPocket()
    {
        if(_components.PadTaker.IsHasBoost == false)
        {
            _effectInPocketIcon.enabled = false;
            _effectInPocketType = TypeOfEffect.Default;
            return;
        }

        if (_components.PadTaker.EffectType == _effectInPocketType)
            return;

        _effectInPocketIcon.enabled = true;

        IBoostEffect effect = EffectsStorage.GetEffect(_components.PadTaker.EffectType);
        _effectInPocketType = effect.TypeOfEffect;
        _effectInPocketIcon.sprite = effect.EffectsIcon;
    }

    private void SetupActieveEffect()
    {
        if (_components.PadUsing.ActieveEffect == null)
        {
            _effectInUseIcon.enabled = false;
            _effectInUseType = TypeOfEffect.Default;
            return;
        }

        if (_components.PadUsing.ActieveEffect.TypeOfEffect == _effectInUseType)
            return;

        _effectInUseIcon.enabled = true;

        _effectInUseType = _components.PadUsing.ActieveEffect.TypeOfEffect;
        _effectInUseIcon.sprite = _components.PadUsing.ActieveEffect.EffectsIcon;
    }

    private void UpdateActieveEffectsProgress()
    {
        if (_components.PadUsing.ActieveEffect == null)
        {
            _effectProgress.fillAmount = 0;
            return;
        }

        _effectProgress.fillAmount = _components.PadUsing.ActieveEffect.Progress;
    }
}
