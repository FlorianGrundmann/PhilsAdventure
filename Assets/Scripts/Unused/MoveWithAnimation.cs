using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class MoveWithAnimation : MoveDecorator
{
    private Animator animator;
    public string AnimationBoolName { get; private set; }

    public MoveWithAnimation(IMove move, Animator animator, string animationBoolName) : base(move)
    {
        AnimationBoolName = animationBoolName;
        this.animator = animator;
    }

    public override void Move()
    {
        animator.SetBool(AnimationBoolName, true);
    }
}

