using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInputView : View
{
    [SerializeField] private Button buttonJump;
    [SerializeField] private Button buttonHitPunch;
    [SerializeField] private Button buttonHitKnife;
    [SerializeField] private Button buttonHitWhip;

    public void Initialize()
    {
        buttonJump.onClick.AddListener(() => OnJump?.Invoke());
        buttonHitPunch.onClick.AddListener(() => OnHitPunch?.Invoke());
        buttonHitKnife.onClick.AddListener(() => OnHitKnife?.Invoke());
        buttonHitWhip.onClick.AddListener(() => OnHitWhip?.Invoke());
    }

    public void Dispose()
    {
        buttonJump.onClick.RemoveListener(() => OnJump?.Invoke());
        buttonHitPunch.onClick.RemoveListener(() => OnHitPunch?.Invoke());
        buttonHitKnife.onClick.RemoveListener(() => OnHitKnife?.Invoke());
        buttonHitWhip.onClick.RemoveListener(() => OnHitWhip?.Invoke());
    }


    #region Output

    public event Action OnHitPunch;
    public event Action OnHitKnife;
    public event Action OnHitWhip;

    public event Action OnJump;

    #endregion
}
