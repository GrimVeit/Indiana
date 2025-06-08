using System;
using UnityEngine;

public class UIMainMenuRoot : UIRoot
{
    [SerializeField] private MoveRotatePanel backgroundPanel;
    [SerializeField] private MainPanel_Menu mainPanel;
    [SerializeField] private LevelPanel_Menu levelPanel;
    [SerializeField] private CollectionPanel_Menu collectionPanel;
    [SerializeField] private InventoryPanel_Menu inventoryPanel;

    private ISoundProvider _soundProvider;

    public void SetSoundProvider(ISoundProvider soundProvider)
    {
        _soundProvider = soundProvider;
    }

    public void Initialize()
    {
        backgroundPanel.Initialize();
        mainPanel.Initialize();
        levelPanel.Initialize();
        collectionPanel.Initialize();
        inventoryPanel.Initialize();
    }

    public void Activate()
    {
        mainPanel.OnClickToLevel += HandleClickToLevel_Main;
        mainPanel.OnClickToCollection += HandleClickToCollection_Main;
        mainPanel.OnClickToInventory += HandleClickToInventory_Main;

        levelPanel.OnClickToBack += HandleClickToBack_Level;
        collectionPanel.OnClickToBack += HandleClickToBack_Collection;
        inventoryPanel.OnClickToBack += HandleClickToBack_Inventory;

        backgroundPanel.ActivatePanel();
    }


    public void Deactivate()
    {
        mainPanel.OnClickToLevel -= HandleClickToLevel_Main;
        mainPanel.OnClickToCollection -= HandleClickToCollection_Main;
        mainPanel.OnClickToInventory -= HandleClickToInventory_Main;

        levelPanel.OnClickToBack -= HandleClickToBack_Level;
        collectionPanel.OnClickToBack -= HandleClickToBack_Collection;
        inventoryPanel.OnClickToBack -= HandleClickToBack_Inventory;

        if (currentPanel != null)
            CloseOtherPanel(currentPanel);

        backgroundPanel.DeactivatePanel();
    }

    public void Dispose()
    {
        backgroundPanel.Dispose();
        mainPanel.Dispose();
        levelPanel.Dispose();
        collectionPanel.Dispose();
        inventoryPanel.Dispose();
    }

    #region Output

    #region MAIN

    public event Action OnClickToLevel_Main;
    public event Action OnClickToInventory_Main;
    public event Action OnClickToCollection_Main;

    private void HandleClickToLevel_Main()
    {
        OnClickToLevel_Main?.Invoke();

        _soundProvider.PlayOneShot("Click");
    }

    private void HandleClickToCollection_Main()
    {
        OnClickToCollection_Main?.Invoke();

        _soundProvider.PlayOneShot("Click");
    }

    private void HandleClickToInventory_Main()
    {
        OnClickToInventory_Main?.Invoke();

        _soundProvider.PlayOneShot("Click");
    }

    #endregion


    #region LEVEL

    public event Action OnClickToBack_Level;

    private void HandleClickToBack_Level()
    {
        OnClickToBack_Level?.Invoke();

        _soundProvider.PlayOneShot("Click");
    }

    #endregion


    #region COLLECTION

    public event Action OnClickToBack_Collection;

    private void HandleClickToBack_Collection()
    {
        OnClickToBack_Collection?.Invoke();

        _soundProvider.PlayOneShot("Click");
    }

    #endregion


    #region INVENTORY

    public event Action OnClickToBack_Inventory;

    private void HandleClickToBack_Inventory()
    {
        OnClickToBack_Inventory?.Invoke();

        _soundProvider.PlayOneShot("Click");
    }

    #endregion

    #endregion

    #region Input

    public void OpenMainPanel()
    {
        OpenPanel(mainPanel);
    }

    public void OpenLevelPanel()
    {
        OpenPanel(levelPanel);
    }

    public void OpenCollectionPanel()
    {
        OpenPanel(collectionPanel);
    }

    public void OpenInventoryPanel()
    {
        OpenPanel(inventoryPanel);
    }

    #endregion
}
