using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameSceneRoot_Game : UIRoot
{
    [SerializeField] private HeaderPanel_Game headerPanel;
    [SerializeField] private FooterPanel_Game footerPanel;

    [SerializeField] private PausePanel_Game pausePanel;
    [SerializeField] private WinPanel_Game winPanel;
    [SerializeField] private LosePanel_Game losePanel;

    private ISoundProvider _soundProvider;

    public void SetSoundProvider(ISoundProvider soundProvider)
    {
        _soundProvider = soundProvider;
    }

    public void Initialize()
    {
        headerPanel.Initialize();
        footerPanel.Initialize();

        pausePanel.Initialize();
        winPanel.Initialize();
        losePanel.Initialize();
    }

    public void Dispose()
    {
        headerPanel.Dispose();
        footerPanel.Dispose();

        pausePanel.Dispose();
        winPanel.Dispose();
        losePanel.Dispose();
    }

    public void Activate()
    {
        headerPanel.OnClickToPause += HandleClickToPause_Header;
        headerPanel.OnClickToExit += HandleClickToExit_Header;

        pausePanel.OnClickToResume += HandleClickToResume_Pause;
    }

    public void Deactivate()
    {
        headerPanel.OnClickToPause -= HandleClickToPause_Header;
        headerPanel.OnClickToExit -= HandleClickToExit_Header;

        pausePanel.OnClickToResume -= HandleClickToResume_Pause;

        if (currentPanel != null)
            CloseOtherPanel(currentPanel);
    }

    #region Output

    #region HEADER

    public event Action OnClickToPause_Header;
    public event Action OnClickToExit_Header;

    private void HandleClickToPause_Header()
    {
        OnClickToPause_Header?.Invoke();
    }

    private void HandleClickToExit_Header()
    {
        OnClickToExit_Header?.Invoke();
    }

    #endregion

    #region PAUSE

    public event Action OnClickToResume_Pause;

    private void HandleClickToResume_Pause()
    {
        OnClickToResume_Pause?.Invoke();
    }

    #endregion

    #endregion

    #region Input

    public void OpenHeaderPanel()
    {
        if (headerPanel.IsActive) return;

        OpenOtherPanel(headerPanel);
    }

    public void CloseHeaderPanel()
    {
        if (!headerPanel.IsActive) return;

        CloseOtherPanel(headerPanel);
    }



    public void OpenFooterPanel()
    {
        if (footerPanel.IsActive) return;

        OpenOtherPanel(footerPanel);
    }

    public void CloseFooterPanel()
    {
        if (!footerPanel.IsActive) return;

        CloseOtherPanel(footerPanel);
    }



    public void OpenPausePanel()
    {
        if (pausePanel.IsActive) return;

        OpenOtherPanel(pausePanel);
    }

    public void ClosePausePanel()
    {
        if (!pausePanel.IsActive) return;

        CloseOtherPanel(pausePanel);
    }



    public void OpenWinPanel()
    {
        OpenOtherPanel(winPanel);
    }

    public void CloseWinPanel()
    {
        CloseOtherPanel(winPanel);
    }



    public void OpenLosePanel()
    {
        OpenOtherPanel(losePanel);
    }

    public void CloseLosePanel()
    {
        CloseOtherPanel(losePanel);
    }

    #endregion
}
