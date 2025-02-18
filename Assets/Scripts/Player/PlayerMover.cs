using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 3.0f;
    [SerializeField] private float _jumpForce = 10.0f;
    [SerializeField] private float _speedScaller = 2f;

    private Rigidbody2D _playerRigidbody;

    private float _direction = 1f;

    private void Awake()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move()
    {
        Vector2 velocity = _playerRigidbody.velocity;

        velocity.x = _moveSpeed * _direction;

        _playerRigidbody.velocity = velocity;
    }

    public void MoveFast()
    {
        Vector2 velocity = _playerRigidbody.velocity;

        velocity.x = _moveSpeed * _speedScaller * _direction;

        _playerRigidbody.velocity = velocity;
    }

    public void Jump()
    {
        _playerRigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    public void SetDirection(float horizontalInput)
    {
        if (horizontalInput != 0)
        {
            _direction = Mathf.Sign(horizontalInput);
        }
    }

    public void StopMoving()
    {
        Vector2 velocity = _playerRigidbody.velocity;

        velocity.x = 0;

        _playerRigidbody.velocity = velocity;
    }
}
