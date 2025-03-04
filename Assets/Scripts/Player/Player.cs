using UnityEngine;

[RequireComponent(typeof(UserInput), typeof(PlayerMover), typeof(PlayerWeapon))]
[RequireComponent(typeof(PlayerAnimation), typeof(GroundDetector), typeof(Collector))]
[RequireComponent(typeof(VampireAbility), typeof(CharacterRotation))]
public class Player : MonoBehaviour, ITargetable
{
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerAnimation _playerAnimation;
    [SerializeField] private UserInput _userInput;
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private PlayerWeapon _weapon;
    [SerializeField] private VampireAbility _ability;
    [SerializeField] private CharacterRotation _rotator;

    public Transform Transform => transform;

    private bool _isRunning;
    private bool _isJumping;
    private bool _jumpRequest;
    private bool _isMoving;
    private bool _isShooting;
    private bool _isShootingCooldown = false;

    private void Awake()
    {
        _userInput.Jumped += HandleJump;
        _userInput.Moved += HandleMove;
        _userInput.Raced += HandleRun;
        _userInput.Fired += HandleFire;
        _userInput.Consumed += HandleConsume;
    }

    private void Update()
    {
        _userInput.ListenKey();
        UpdateAnimation();
    }

    private void FixedUpdate()
    {
        _rotator.Flip(_userInput);
        UpdateMove();
    }

    private void UpdateMove()
    {
        if (_jumpRequest && _groundDetector.IsGround)
        {
            _playerMover.Jump(); 
            _jumpRequest = false; 
            _isJumping = true;
        }

        if (_isMoving)
            UpdateMoveHorizontal();
        else
            _playerMover.StopMove();
    }

    private void UpdateMoveHorizontal()
    {
        if (_isRunning)
            _playerMover.MoveFast();
        else
            _playerMover.Move();
    }

    private void HandleFire()
    {
        if (_groundDetector.IsGround && _isJumping == false && _userInput.HorizontalInput == 0)
        {
            _isShooting=true;
            _weapon.TryShoot(out bool isCooldown);
            _isShootingCooldown=isCooldown;
        }
        else
            _isShooting = false;
    }
    
    private void HandleConsume()
    {
        if (_ability.IsOnCooldown == false)
            _ability.TryConsume();
    }

    private void HandleJump()
    {
        if (_groundDetector.IsGround && _isJumping == false) 
        {
            _jumpRequest = true;
            _playerAnimation.PlayJump();
        }
    }

    private void HandleMove(float direction)
    {
        if (_userInput.HorizontalInput != 0)
        {
            _playerMover.SetDirection(direction);
            _isMoving = true;
        }
        else
            _isMoving = false;
    }

    private void HandleRun(bool isRunning)
    {
        _isRunning = isRunning;
    }

    private void UpdateAnimation()
    {
        if (_isShooting == true && _isShootingCooldown == false)
        {
            UpdateShoot(); 
            return; 
        }

        if (_groundDetector.IsGround)
            UpdateAnimationHorizontal();
        else
        {
            if (_isJumping)
                return;

            _playerAnimation.PlayFall();
        }
    }

    private void UpdateShoot()
    {
        if (_userInput.HorizontalInput == 0)
        {
            _playerAnimation.PlayShoot(); 
            _isShooting = false;
        }
        else
        {
            _isShooting = false;
        }
    }

    private void UpdateAnimationHorizontal()
    {
        _isJumping = false;

        if(_userInput.HorizontalInput == 0)
            _playerAnimation.PlayIdle();
        else if (_isRunning)
            _playerAnimation.PlayRun(_userInput);
        else
            _playerAnimation.PlayWalk(_userInput);
    }
}
