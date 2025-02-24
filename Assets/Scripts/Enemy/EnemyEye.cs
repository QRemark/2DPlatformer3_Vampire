using UnityEngine;

public class EnemyEye : MonoBehaviour
{
    public delegate void EyeEventHandler(Collider2D collider);
    public event EyeEventHandler OnEnterSight;
    public event EyeEventHandler OnExitSight;

    [SerializeField] private LayerMask _targetLayers;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & _targetLayers) == 0)
            return;

        OnEnterSight?.Invoke(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & _targetLayers) == 0)
            return;

        OnExitSight?.Invoke(collision);
    }
}