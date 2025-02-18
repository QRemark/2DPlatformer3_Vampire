using UnityEngine;

[RequireComponent(typeof(Wallet), typeof(PlayerHealthContainer))]
public class Collector : MonoBehaviour
{
    private Wallet _wallet;
    private PlayerHealthContainer _healthContainer;

    private void Awake()
    {
        _wallet = GetComponent<Wallet>();
        _healthContainer = GetComponent<PlayerHealthContainer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<ICollectible>(out var collectible)) //var
        {
            collectible.Collect();

            if(collectible is Coin)
            {
                _wallet.ChangeCoinsNumber();
            }
            else if (collectible is MedicineChest medicineChest)
            {
                float healtRange = medicineChest.GetHealthRange();
                _healthContainer.Increase(healtRange);
            }
            
        }
    }
}
