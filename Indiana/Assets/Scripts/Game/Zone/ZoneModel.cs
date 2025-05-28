using System;
using System.Numerics;

public class ZoneModel
{
    public event Action OnStart;
    public event Action OnStop;

    public event Action<ZoneType, Vector3> OnSpawnZone;

    private ICameraProvider _cameraProvider;

    public ZoneModel(ICameraProvider cameraProvider)
    {
        _cameraProvider = cameraProvider;
    }

    public void SpawnZone(ZoneType zoneType, Vector3 position)
    {
        if (zoneType == ZoneType.Usual) return;
        
        OnSpawnZone?.Invoke(zoneType, position);
    }

    public void SendZone(ZoneType type)
    {
        switch (type)
        {
            case ZoneType.Start:
                OnStart?.Invoke();
                _cameraProvider.ActivateLookAt();
                return;
            case ZoneType.End:
                OnStop?.Invoke();
                _cameraProvider.DeactivateLookAt();
                return;
        }
    }
}
