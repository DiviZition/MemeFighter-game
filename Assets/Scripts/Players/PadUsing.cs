using UnityEngine;

public class PadUsing : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private PadTaker _padTaker;

    private IBoostEffect _boostEffect;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && _boostEffect == null)
        {
            if (_padTaker.EffectType == TypeOfEffect.Default)
                return;

            _boostEffect = EffectsStorage.GetEffect(_padTaker.EffectType);
            _padTaker.ResetEffect();
        }

        if (_boostEffect == null)
            return;

        _boostEffect.DoLogic(_transform);
        
        if (_boostEffect.IsEnded == true)
        {
            _boostEffect.ResetValues();
            _boostEffect = null;
            return;
        }
    }
}
