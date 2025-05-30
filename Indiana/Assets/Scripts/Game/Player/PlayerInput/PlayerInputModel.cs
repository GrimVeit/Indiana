using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputModel
{
    private IPlayerJumpMoveProvider _jumpMoveProvider;
    private IPlayerAnimationProvider _animationProvider;

    public PlayerInputModel(IPlayerJumpMoveProvider jumpMoveProvider, IPlayerAnimationProvider animationProvider)
    {
        _jumpMoveProvider = jumpMoveProvider;
        _animationProvider = animationProvider;
    }

    public void Jump()
    {
        _jumpMoveProvider.Jump();
        _animationProvider.Jump();
    }

    public void HitPunch()
    {

    }

    public void HitKnife()
    {

    }

    public void HitWhip()
    {

    }
}
