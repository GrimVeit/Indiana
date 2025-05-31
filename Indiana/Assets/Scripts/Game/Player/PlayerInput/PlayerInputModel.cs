using System;

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
        OnClickToHitPunch?.Invoke();
    }

    public void HitKnife()
    {
        OnClickToHitKnife?.Invoke();
    }

    public void HitWhip()
    {
        OnClickToHitWhip?.Invoke();
    }

    #region Output

    public event Action OnClickToHitPunch;
    public event Action OnClickToHitKnife;
    public event Action OnClickToHitWhip;

    #endregion
}
