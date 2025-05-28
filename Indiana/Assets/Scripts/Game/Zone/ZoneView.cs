using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ZoneView : View
{
    [SerializeField] private ZoneIndexes ZoneIndexes;

    private readonly List<Zone> _spawnedTrophies = new();

    public void SpawnZone(ZoneType zoneType, System.Numerics.Vector3 position)
    {
        var prefab = ZoneIndexes.GetZoneByType(zoneType);

        var zone = Instantiate(prefab, new Vector3(position.X, position.Y, position.Z), prefab.transform.rotation);
        zone.OnSendZone += SendZone;

        _spawnedTrophies.Add(zone);
    }

    #region Output

    public event Action<ZoneType> OnSendZone;

    private void SendZone(ZoneType zoneType)
    {
        OnSendZone?.Invoke(zoneType);
    }

    #endregion
}

[Serializable]
public class ZoneIndexes
{
    [SerializeField] private List<ZoneIndex> zoneIndexes = new();

    public Zone GetZoneByType(ZoneType zoneType)
    {
        return zoneIndexes.FirstOrDefault(data => data.ZoneType == zoneType).Zone;
    }
}

[Serializable]
public class ZoneIndex
{
    public Zone Zone => zone;
    public ZoneType ZoneType => zoneType;

    [SerializeField] private Zone zone;
    [SerializeField] private ZoneType zoneType;
}
