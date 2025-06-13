using System;
using System.Collections;
using UnityEngine;

public class InternetModel
{
    public event Action<string> OnGetStatusDescription;
    public event Action OnInternetAvailable;
    public event Action OnInternetUnvailable;

    public void StartCheckConnection()
    {
        Coroutines.Start(CheckInternet_Coroutine());

        //if (Application.internetReachability == NetworkReachability.NotReachable)
        //{
        //    Debug.Log("Internet disable");
        //    OnConnectionUnvailable?.Invoke();
        //    OnGetStatusDescription?.Invoke("Unable to connect. Please check your internet connection");
        //}
        //else
        //{
        //    Debug.Log("Internet enable");
        //    OnConnectionAvailable?.Invoke();
        //}
    }

    private IEnumerator CheckInternet_Coroutine()
    {
        while (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("Подключения к интернету нет");
            OnGetStatusDescription?.Invoke("Please check internet connection...");
            OnInternetUnvailable?.Invoke();
            yield return new WaitForSeconds(1);
        }

        Debug.Log("Подключения к интернету есть");
        OnGetStatusDescription?.Invoke("Load data...");
        OnInternetAvailable?.Invoke();
    }
}
