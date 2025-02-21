using UnityEngine;

public class VampireAbilityAnimation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _abilitySprite;

    private void Awake()
    {
        _abilitySprite.enabled = false;
    }

    public void PlayVampireAbilityAnimation()
    {
        _abilitySprite.enabled = true;
    }

    public void StopVampireAbilityAnimation()
    {
        _abilitySprite.enabled = false;
    }
}
