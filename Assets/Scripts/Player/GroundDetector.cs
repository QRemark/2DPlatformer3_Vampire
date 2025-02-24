using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayer;

    public bool IsGround { get; private set; }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & _groundLayer) == 0)
            return;

        if (collision.gameObject.TryGetComponent<JumpPlatform>(out _))
        {
            IsGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & _groundLayer) == 0)
            return;

        if (collision.gameObject.TryGetComponent<JumpPlatform>(out _))
        {
            IsGround = false;
        }
    }
}
