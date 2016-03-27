using UnityEngine;

public class Movement : IMove
{
    private Rigidbody2D body;
    private float speed;
    private Vector3 direction;

    public Movement(Rigidbody2D body, float speed)
    {
        throw new System.NotImplementedException();
    }

    public float Speed
    {
        get
        {
            throw new System.NotImplementedException();
        }

        set
        {
        }
    }

    public Vector3 Direction
    {
        get
        {
            throw new System.NotImplementedException();
        }

        set
        {
        }
    }

    public void Jump()
    {
        throw new System.NotImplementedException();
    }
}