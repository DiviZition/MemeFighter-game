using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    private PlayerHealth _playerHealth;

    private void FixedUpdate()
    {
        if (_playerHealth == null)
        {
            _healthBar.fillAmount = 0;
            return;
        }

        _healthBar.fillAmount = _playerHealth.CurrentHealth / _playerHealth.StartHealth;
    }

    public void LinkToPlayer(PlayerHealth playerHealth) => _playerHealth = playerHealth;
}
