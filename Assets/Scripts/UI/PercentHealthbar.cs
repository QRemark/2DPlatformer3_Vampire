using UnityEngine;
using UnityEngine.UI;

public class PercentHealthbar : MonoBehaviour
{
    [SerializeField] private Slider _percentHealthbar;

    private IHealthContainer _healthContainer; 

    private void Start()
    {
        _healthContainer = GetComponentInParent<IHealthContainer>();

        if (_healthContainer != null)
        {
            _healthContainer.HealthChanged += UpdatePercentHealthbar;
            UpdatePercentHealthbar(_healthContainer.CurrentHealth, _healthContainer.MaxHealth);
        }
    }

    private void OnDestroy()
    {
        _healthContainer.HealthChanged -= UpdatePercentHealthbar;
    }

    private void UpdatePercentHealthbar(float currentHealth, float maxHealth)
    {
        _percentHealthbar.value = currentHealth / maxHealth;
    }
}
