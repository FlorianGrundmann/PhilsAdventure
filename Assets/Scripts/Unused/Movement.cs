using UnityEngine;

public class Movement : IDirectionalMove
{
    private Rigidbody2D body;

    public float Speed
    {
        get;
        private set;
    }

    private Vector3 direction;
    public Vector3 Direction
    {
        get { return direction; }
        set
        {
            direction = Vector3.Normalize(value);
        }
    }

    public Movement(Rigidbody2D body, float speed, Vector3 direction)
    {
        this.body = body;
        this.Speed = speed;
        this.Direction = direction;
    }

    

    public void Move()
    {
        Vector3 speedVector = GetSpeedVector3();
        body.velocity = new Vector2(speedVector.x, speedVector.y);
    }

    public void Move(Vector3 direction)
    {
        Direction = direction;
        Move();
    }

    private Vector3 GetSpeedVector3()
    {
        float xSpeed = Direction.x * Speed;
        float ySpeed = Direction.y * Speed;
        float zSpeed = Direction.z * Speed;
        return new Vector3(xSpeed, ySpeed, zSpeed);
    }
}