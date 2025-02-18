using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GradualHealthbar : MonoBehaviour
{
    [SerializeField] private Slider _gradualHealthbar;

    private IHealthContainer _healthContainer;

    private void Start()
    {
        _healthContainer = GetComponentInParent<IHealthContainer>();

        if (_healthContainer != null)
        {
            _healthContainer.HealthChanged += UpdateGradualHealthbar;
            UpdateGradualHealthbar(_healthContainer.CurrentHealth, _healthContainer.MaxHealth);
        }
    }

    private void OnDestroy()
    {
        _healthContainer.HealthChanged -= UpdateGradualHealthbar;
    }

    private void UpdateGradualHealthbar(float currentHealth, float maxHealth)
    {
        float targetValue = currentHealth / maxHealth;
        StopAllCoroutines();
        StartCoroutine(SmoothHealthChange(targetValue));
    }

    private IEnumerator SmoothHealthChange(float targetHealth)
    {
        float startValue = _gradualHealthbar.value;
        float elapsedTime = 0f;
        float animationTime = 1f;

        while (elapsedTime < animationTime)
        {
            elapsedTime += Time.deltaTime / animationTime;
            _gradualHealthbar.value = Mathf.Lerp(startValue, targetHealth, elapsedTime);

            yield return null;
        }

        _gradualHealthbar.value = targetHealth;
    }
}
