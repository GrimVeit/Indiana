using System;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneView : View
{
    [SerializeField] private List<DeadZone> deadZones = new List<DeadZone>();

    public void Initialize()
    {
        deadZones.ForEach(data =>
        {
            data.OnSendDeadZone += SendDeadZone;
            data.Initialize();
        });
    }

    public void Dispose()
    {
        deadZones.ForEach(data =>
        {
            data.OnSendDeadZone -= SendDeadZone;
            data.Initialize();
        });
    }

    #region Output

    public event Action OnSendDeadZone;

    private void SendDeadZone()
    {
        OnSendDeadZone?.Invoke();
    }

    #endregion
}
