using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _coinsInPocket = 0;

    public void ChangeCoinsNumber()
    {
        _coinsInPocket++;
    }
}