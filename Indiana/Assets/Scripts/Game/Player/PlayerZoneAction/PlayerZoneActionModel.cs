using System;

public class PlayerZoneActionModel
{
    public event Action OnActivateSmallZone;
    public event Action OnActivateMiddleZone;
    public event Action OnActivateBigZone;

    public void ActivateSmallZone()
    {
        OnActivateSmallZone?.Invoke();
    }

    public void ActivateMiddleZone()
    {
        OnActivateMiddleZone?.Invoke();
    }

    public void ActivateBigZone()
    {
        OnActivateBigZone?.Invoke();
    }
}
