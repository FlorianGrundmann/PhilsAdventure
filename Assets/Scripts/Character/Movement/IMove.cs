using UnityEngine;
public interface IMove
{
    float Speed { get; set; }
    Vector3 Direction { get; set; }

    void Jump();
}