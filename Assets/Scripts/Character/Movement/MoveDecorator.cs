using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Character.Movement
{
    abstract class MoveDecorator: IMove
    {
        protected IMove move;

        public MoveDecorator(IMove move)
        {
            this.move = move;
        }

        public abstract void Move();
        
    }
}
