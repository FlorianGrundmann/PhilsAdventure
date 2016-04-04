using System;
using UnityEngine;

public class Jumping : IMove
{
    private float jumpHeight;
    private Rigidbody2D body;
    private GroundChecker groundChecker;

    public Jumping(Rigidbody2D body, GroundChecker groundCheck, float jumpHeight)
    {
        this.body = body;
        this.groundChecker = groundCheck;
        this.jumpHeight = jumpHeight;
    }

    public void Move()
    {
        if (groundChecker.IsOnGround)
            Jump();

    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpHeight);
    }
}