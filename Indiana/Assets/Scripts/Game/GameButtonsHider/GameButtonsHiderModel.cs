using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButtonsHiderModel
{
    public event Action OnShowButtons;
    public event Action OnHideButtons;

    private readonly IPlayerGroundEventsProvider _groundEventsProvider;

    public GameButtonsHiderModel(IPlayerGroundEventsProvider groundEventsProvider)
    {
        _groundEventsProvider = groundEventsProvider;

        _groundEventsProvider.OnPlayerInGround += Hide;
        _groundEventsProvider.OnPlayerOutGround += Show;
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {
        _groundEventsProvider.OnPlayerInGround -= Hide;
        _groundEventsProvider.OnPlayerOutGround -= Show;
    }

    public void Show()
    {
        OnShowButtons?.Invoke();
    }

    public void Hide()
    {
        OnHideButtons?.Invoke();
    }
}
