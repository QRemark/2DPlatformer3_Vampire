using UnityEngine;

public class EnemyEye : MonoBehaviour
{
    public delegate void EyeEventHandler(Collider2D collider);
    public event EyeEventHandler OnEnterSight;
    public event EyeEventHandler OnExitSight;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnEnterSight?.Invoke(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        OnExitSight?.Invoke(collision);
    }
}