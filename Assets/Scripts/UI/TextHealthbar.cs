using TMPro;
using UnityEngine;

public class TextHealthbar : MonoBehaviour
{
    [SerializeField] private TMP_Text _healthText;

    private IHealthContainer _healthContainer;

    private float MaxHealth => _healthContainer.Max;

    private void Start()
    {
        _healthContainer = GetComponentInParent<IHealthContainer>();

        if (_healthContainer != null)
        {
            _healthContainer.Changed += UpdateHealthText;
            UpdateHealthText(_healthContainer.Current);
        }
    }

    private void OnDestroy()
    {
        if (_healthContainer != null)
            _healthContainer.Changed -= UpdateHealthText;
    }

    private void UpdateHealthText(float currentHealth)
    {
        _healthText.text = $"{currentHealth} / {MaxHealth}";
    }
}
