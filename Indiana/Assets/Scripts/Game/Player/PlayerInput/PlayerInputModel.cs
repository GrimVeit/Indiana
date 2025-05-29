using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputModel
{
    private IPlayerJumpMoveProvider _jumpMoveProvider;

    public PlayerInputModel(IPlayerJumpMoveProvider jumpMoveProvider)
    {
        _jumpMoveProvider = jumpMoveProvider;
    }

    public void Jump()
    {
        _jumpMoveProvider.Jump();
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
