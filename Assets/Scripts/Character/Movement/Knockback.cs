using UnityEngine;

public class Knockback : IMove
{
    private float speed;
    private float time;
    private Rigidbody2D body;
    private Vector3 direction;

    public Knockback(float speed, float time)
    {
        throw new System.NotImplementedException();
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

    public void Jump()
    {
        throw new System.NotImplementedException();
    }
}