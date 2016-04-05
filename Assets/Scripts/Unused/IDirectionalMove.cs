using System;
using UnityEngine;


interface IDirectionalMove : IMove
{
    Vector3 Direction { get; set; }
    void Move(Vector3 direction);
}

