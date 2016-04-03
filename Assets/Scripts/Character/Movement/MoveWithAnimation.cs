using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Character.Movement
{
    class MoveWithAnimation:MoveDecorator
    {
        public MoveWithAnimation(IMove move, string animationName):base(move)
        {
            throw new NotImplementedException();
        }

        public string AnimationName
        {
            get;
            private set;
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }
    }
}
