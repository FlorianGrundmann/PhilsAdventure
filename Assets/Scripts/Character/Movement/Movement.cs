using UnityEngine;

public class Movement : IMove
{
    private Rigidbody2D body;

    public Movement(Rigidbody2D body, float speed, Vector3 direction)
    {
        throw new System.NotImplementedException();
    }

    public float Speed
    {
        get;
        private set;
    }

    public Vector3 Direction
    {
        get;
        private set;
    }

    public void Move()
    {
        throw new System.NotImplementedException();
    }
}