using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
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

        _healthBar.fillAmount = _playerHealth.CurrentHealth / _playerHealth.StartHealth;
    }
}
