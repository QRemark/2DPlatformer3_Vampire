using UnityEngine;

public class CharacterRotation : MonoBehaviour
{
    private Quaternion _rotateLeft = Quaternion.Euler(0, 180, 0);
    private Quaternion _rotateRight = Quaternion.identity;

    public void Flip(UserInput userInput)
    {
        if (userInput.HorizontalInput < 0.0f)
            transform.localRotation = _rotateLeft;
        else if (userInput.HorizontalInput > 0.0f)
            transform.localRotation = _rotateRight;
    }
}
