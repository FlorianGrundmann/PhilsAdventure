using UnityEngine;

public class Knockback : IMove
{
    private float time;
    private Rigidbody2D body;

    public Knockback(float speed, float time)
    {
        throw new System.NotImplementedException();
    }

    public Vector3 Direction
    {
        get;
        private set;
    }

    public float Speed
    {
        get;
        private set;
    }

    public void Move()
    {
        throw new System.NotImplementedException();
    }
}