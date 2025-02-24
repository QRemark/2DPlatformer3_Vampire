using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VampireAbilityBar : MonoBehaviour
{
    [SerializeField] private Slider _abilityBar;

    private Coroutine _fillCoroutine;

    private float _startPosition = 1f;
    private float _endPosition = 0f;

    private void Awake()
    {
        if (_abilityBar != null)
            _abilityBar.value = _startPosition;
    }

    public void StartVampireBar(float duration)
    {
        if (_fillCoroutine != null)
            StopCoroutine(_fillCoroutine);

        _fillCoroutine = StartCoroutine(ChangeFill(duration, _startPosition, _endPosition));
    }

    public void StartVampireBarCooldown(float cooldown)
    {
        if (_fillCoroutine != null)
            StopCoroutine(_fillCoroutine);

        _fillCoroutine = StartCoroutine(ChangeFill(cooldown, _endPosition, _startPosition));
    }

    private IEnumerator ChangeFill(float time, float startPosition, float endPosition)
    {
        float elapsedTime = 0f;

        while (elapsedTime < time)
        {
            _abilityBar.value = Mathf.Lerp(startPosition, endPosition, elapsedTime / time);
            elapsedTime += Time.deltaTime;

            yield return null;
        }
    }
}
