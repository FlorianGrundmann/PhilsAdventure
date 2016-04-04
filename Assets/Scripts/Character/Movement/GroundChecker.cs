using UnityEngine;

public class GroundChecker
{
    private Transform groundCheckerTransform;
    private float groundCheckRadius;
    private LayerMask layerMaskGround;

    public GroundChecker(Transform groundCheckerTransform, float groundCheckRadius, LayerMask layerMaskGround)
    {
        this.groundCheckerTransform = groundCheckerTransform;
        this.groundCheckRadius = groundCheckRadius;
        this.layerMaskGround = layerMaskGround;
    }

    public bool IsOnGround
    {
        get
        {
            Vector2 checkPos = new Vector2(groundCheckerTransform.position.x, groundCheckerTransform.position.y);
            return Physics2D.OverlapCircle(checkPos, groundCheckRadius, layerMaskGround);
        }
    }
}