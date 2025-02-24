using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GradualHealthbar : MonoBehaviour
{
    [SerializeField] private Slider _gradualHealthbar;

    private IHealthContainer _healthContainer;

    private float MaxHealth => _healthContainer.Max;

    private void Start()
    {
        _healthContainer = GetComponentInParent<IHealthContainer>();

        if (_healthContainer != null)
        {
            _healthContainer.Changed += UpdateGradualHealthbar;
            UpdateGradualHealthbar(_healthContainer.Current);
        }
    }

    private void OnDestroy()
    {
        if (_healthContainer != null)
            _healthContainer.Changed -= UpdateGradualHealthbar;
    }

    private void UpdateGradualHealthbar(float currentHealth)
    {
        float targetValue = currentHealth / MaxHealth;
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
