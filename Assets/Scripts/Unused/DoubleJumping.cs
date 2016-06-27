using UnityEngine;

public class DoubleJumping : Jumping, IMove
{
    public bool AlreadyDoubleJumped
    {
        get;
        private set;
    }

    public DoubleJumping(Rigidbody2D body, GroundChecker groundCheck, float jumpHeight):base(body, groundCheck, jumpHeight)
    {

    }

    public override void Move()
    {
        if (!this.IsJumping)
        {
            AlreadyDoubleJumped = false;
            Jump();
        }
        else if (!AlreadyDoubleJumped)
        {
            AlreadyDoubleJumped = true;
            Jump();
        }
            
    }
}