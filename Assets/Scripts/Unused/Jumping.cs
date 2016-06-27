using System;
using UnityEngine;

public class Jumping : IMove
{
    private float jumpHeight;
    private Rigidbody2D body;
    private GroundChecker groundChecker;


    private bool isJumping;
    protected bool IsJumping {
        get
        {
           if (groundChecker.IsOnGround)
                isJumping = false;

           return isJumping;
        }
        private set
        {
            isJumping = value;
        }
    }


    public Jumping(Rigidbody2D body, GroundChecker groundCheck, float jumpHeight)
    {
        this.body = body;
        this.groundChecker = groundCheck;
        this.jumpHeight = jumpHeight;
    }

    public virtual void Move()
    {
        if (groundChecker.IsOnGround)
            Jump();
    }

    protected void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpHeight);
        IsJumping = true;
    }
}