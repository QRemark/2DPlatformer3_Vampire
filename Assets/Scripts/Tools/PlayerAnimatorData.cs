using UnityEngine;

public static class PlayerAnimatorData
{
    public static class Params
    {
        public static readonly int Speed = Animator.StringToHash(nameof(Speed));
        public static readonly int IsGrounded = Animator.StringToHash(nameof(IsGrounded));
        public static readonly int JumpTrigger = Animator.StringToHash(nameof(JumpTrigger));
        public static readonly int ShootTrigger = Animator.StringToHash(nameof(ShootTrigger));
    }
}
