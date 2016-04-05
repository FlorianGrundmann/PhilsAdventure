using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


abstract class MoveDecorator : IMove
{
    protected IMove move;

    public MoveDecorator(IMove move)
    {
        this.move = move;
    }

    public abstract void Move();

}

