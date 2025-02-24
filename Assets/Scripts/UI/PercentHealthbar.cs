using UnityEngine;
using UnityEngine.UI;

public class PercentHealthbar : MonoBehaviour
{
    [SerializeField] private Slider _percentHealthbar;

    private IHealthContainer _healthContainer;

    private float MaxHealth => _healthContainer.Max;

    private void Start()
    {
        _healthContainer = GetComponentInParent<IHealthContainer>();

        if (_healthContainer != null)
        {
            _healthContainer.Changed += UpdatePercentHealthbar;
            UpdatePercentHealthbar(_healthContainer.Current);
        }
    }

    private void OnDestroy()
    {
        if (_healthContainer != null)
            _healthContainer.Changed -= UpdatePercentHealthbar;
    }

    private void UpdatePercentHealthbar(float currentHealth)
    {
        _percentHealthbar.value = currentHealth / MaxHealth;
    }
}
