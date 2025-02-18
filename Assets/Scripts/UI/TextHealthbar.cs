using TMPro;
using UnityEngine;

public class TextHealthbar : MonoBehaviour
{
    [SerializeField] private TMP_Text _healthText;

    private IHealthContainer _healthContainer;

    private void Start()
    {
        _healthContainer = GetComponentInParent<IHealthContainer>();

        if (_healthContainer != null)
        {
            _healthContainer.HealthChanged += UpdateHealthText;
            UpdateHealthText(_healthContainer.CurrentHealth, _healthContainer.MaxHealth);
        }
    }

    private void OnDestroy()
    {
        _healthContainer.HealthChanged -= UpdateHealthText;
    }

    private void UpdateHealthText(float currentHealth, float maxHealth)
    {
        _healthText.text = $"{currentHealth} / {maxHealth}";
    }
}
