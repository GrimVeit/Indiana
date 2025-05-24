using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraView : View
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private Transform transformPlayer;

    public void ActivateLookAt()
    {
        virtualCamera.Follow = transformPlayer;
        virtualCamera.LookAt = transformPlayer;
    }

    public void DeactivateLookAt()
    {
        virtualCamera.Follow = null;
        virtualCamera.LookAt = null;
    }
}
