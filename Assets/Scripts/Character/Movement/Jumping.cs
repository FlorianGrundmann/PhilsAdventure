using UnityEngine;

public class Jumping : IJump
{
    private int speed;
    private Rigidbody2D body;
    private GroundChecker groundChecker;
    private Vector3 direction;

    public Jumping(Rigidbody2D body, float speed)
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