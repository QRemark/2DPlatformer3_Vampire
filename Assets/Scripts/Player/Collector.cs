using UnityEngine;

[RequireComponent(typeof(Wallet), typeof(PlayerHealthContainer))]
public class Collector : MonoBehaviour
{
    [SerializeField] private LayerMask _collectibleLayers;

    private Wallet _wallet;
    private PlayerHealthContainer _healthContainer;

    private void Awake()
    {
        _wallet = GetComponent<Wallet>();
        _healthContainer = GetComponent<PlayerHealthContainer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & _collectibleLayers) == 0)
            return;


        if (collision.TryGetComponent<ICollectible>(out var collectible))
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
