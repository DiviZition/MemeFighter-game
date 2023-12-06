using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    [SerializeField] private Image _deathProtection;
    [SerializeField] private Image _oneHitShield;

    private PlayerHealth _playerHealth;

    [Inject]
    private void Construct(PlayerComponents components)
    {
        _playerHealth = components.Health;
    }

    private void FixedUpdate()
    {
        if (_playerHealth == null)
        {
            _healthBar.fillAmount = 0;
            return;
        }

        SetupHealthBurFilling();
        SetupEffectsIconsActieve();
    }

    private void SetupHealthBurFilling()
    {
        _healthBar.fillAmount = (float)_playerHealth.CurrentHealth / (float)_playerHealth.StartHealth;
    }

    private void SetupEffectsIconsActieve()
    {
        _deathProtection.enabled = _playerHealth.IsHaveDeathProtection;
        _oneHitShield.enabled = _playerHealth.IsHaveHitProtection;
    }
}
