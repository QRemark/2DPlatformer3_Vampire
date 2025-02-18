using UnityEngine;
using System;

public class UserInput : MonoBehaviour
{
    private const string HorizontalMoveButtons = "Horizontal";

    private KeyCode _shiftKey = KeyCode.LeftShift;
    private KeyCode _spaceKey = KeyCode.Space;
    private KeyCode _fireKey = KeyCode.E;

    public event Action Jumped;
    public event Action<float> Moved;
    public event Action<bool> Raced;
    public event Action Fired;

    public float HorizontalInput { get; private set; }

    public bool ShiftInput { get; private set; }

    public void ListenKey()
    {
        HorizontalInput = Input.GetAxis(HorizontalMoveButtons);
        Moved?.Invoke(HorizontalInput);

        if (Input.GetKeyDown(_spaceKey))
        {
            Jumped?.Invoke();
        }

        ShiftInput = Input.GetKey(_shiftKey);
        Raced?.Invoke(ShiftInput);

        if (Input.GetKeyDown(_fireKey))
        {
            Fired?.Invoke();
        }
    }
}
