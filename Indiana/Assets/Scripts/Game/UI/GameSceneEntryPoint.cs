using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneEntryPoint : MonoBehaviour
{
    [SerializeField] private int secondLevel;
    [SerializeField] private Sounds sounds;
    [SerializeField] private ItemCollectionGroup itemCollectionGroup;
    [SerializeField] private WeaponGroup weaponGroup;
    [SerializeField] private ClothesDesignGroup clothesDesignGroup;
    [SerializeField] private PlayerDesignGroup playerDesignGroup;
    [SerializeField] private PlatformPathGroup platformPathGroup;
    [SerializeField] private UIGameSceneRoot_Game menuRootPrefab;

    private UIGameSceneRoot_Game sceneRoot;
    private ViewContainer viewContainer;

    private BankPresenter bankPresenter;
    private ParticleEffectPresenter particleEffectPresenter;
    private SoundPresenter soundPresenter;

    private StoreWeaponPresenter storeWeaponPresenter;
    private WeaponGameVisualPresenter weaponGameVisualPresenter;

    private StoreClothesPresenter storeClothesPresenter;
    private StorePlayerPresenter storePlayerPresenter;

    private PlatformSpawnPresenter platformSpawnPresenter;
    private ObstacleSpawnerPresenter obstacleSpawnerPresenter;
    private TrophySpawnerPresenter trophySpawnerPresenter;
    private WeaponSpawnerPresenter weaponSpawnerPresenter;
    private CoinSpawnerPresenter coinSpawnerPresenter;

    private HealthPresenter healthPresenter;

    private PlayerDamageEffectPresenter playerDamageEffectPresenter;
    private PlayerMovePresenter playerMovePresenter;
    private PlayerColliderPresenter playerColliderPresenter;
    private PlayerInputPresenter playerInputPresenter;
    private PlayerZoneActionPresenter playerZoneActionPresenter;
    private PlayerAnimationPresenter playerAnimationPresenter;

    private GameButtonsHiderPresenter gameButtonsHiderPresenter;

    private StoreLevelPresenter storeLevelPresenter;
    private StoreCollectionPresenter storeCollectionPresenter;

    private ZonePresenter zonePresenter;
    private DeadZonePresenter deadZonePresenter;

    private CameraPresenter cameraPresenter;

    private AnimationElementPresenter animationElementPresenter;

    private GameStateMachine gameStateMachine;

    public void Run(UIRootView uIRootView)
    {
        sceneRoot = menuRootPrefab;

        uIRootView.AttachSceneUI(sceneRoot.gameObject, Camera.main);

        viewContainer = sceneRoot.GetComponent<ViewContainer>();
        viewContainer.Initialize();

        soundPresenter = new SoundPresenter
            (new SoundModel(sounds.sounds, PlayerPrefsKeys.IS_MUTE_SOUNDS),
            viewContainer.GetView<SoundView>());

        particleEffectPresenter = new ParticleEffectPresenter
            (new ParticleEffectModel(),
            viewContainer.GetView<ParticleEffectView>());

        bankPresenter = new BankPresenter(new BankModel(), viewContainer.GetView<BankView>());

        storeLevelPresenter = new StoreLevelPresenter(new StoreLevelModel());
        storeCollectionPresenter = new StoreCollectionPresenter(new StoreCollectionModel(itemCollectionGroup));

        storeWeaponPresenter = new StoreWeaponPresenter(new StoreWeaponModel(weaponGroup));
        weaponGameVisualPresenter = new WeaponGameVisualPresenter(new WeaponGameVisualModel(storeWeaponPresenter), viewContainer.GetView<WeaponGameVisualView>());

        storeClothesPresenter = new StoreClothesPresenter(new StoreClothesModel(clothesDesignGroup));
        storePlayerPresenter = new StorePlayerPresenter(new StorePlayerModel(storeClothesPresenter, playerDesignGroup));

        playerMovePresenter = new PlayerMovePresenter(new PlayerMoveModel(), viewContainer.GetView<PlayerMoveView>());
        playerColliderPresenter = new PlayerColliderPresenter(new PlayerColliderModel(), viewContainer.GetView<PlayerColliderView>());
        playerAnimationPresenter = new PlayerAnimationPresenter(new PlayerAnimationModel(storePlayerPresenter, playerMovePresenter), viewContainer.GetView<PlayerAnimationView>());
        playerInputPresenter = new PlayerInputPresenter(new PlayerInputModel(playerMovePresenter, playerAnimationPresenter), viewContainer.GetView<PlayerInputView>());
        playerDamageEffectPresenter = new PlayerDamageEffectPresenter(new PlayerDamageEffectModel(), viewContainer.GetView<PlayerDamageEffectView>());
        healthPresenter = new HealthPresenter(new HealthModel(5, playerDamageEffectPresenter), viewContainer.GetView<HealthView>());

        cameraPresenter = new CameraPresenter(new CameraModel(), viewContainer.GetView<CameraView>());

        playerZoneActionPresenter = new PlayerZoneActionPresenter(new PlayerZoneActionModel(), viewContainer.GetView<PlayerZoneActionView>());
        deadZonePresenter = new DeadZonePresenter(new DeadZoneModel(healthPresenter), viewContainer.GetView<DeadZoneView>());
        zonePresenter = new ZonePresenter(new ZoneModel(cameraPresenter), viewContainer.GetView<ZoneView>());
        coinSpawnerPresenter = new CoinSpawnerPresenter(new CoinSpawnerModel(bankPresenter), viewContainer.GetView<CoinSpawnerView>());
        trophySpawnerPresenter = new TrophySpawnerPresenter(new TrophySpawnerModel(storeCollectionPresenter), viewContainer.GetView<TrophySpawnerView>());
        weaponSpawnerPresenter = new WeaponSpawnerPresenter(new WeaponSpawnerModel(storeWeaponPresenter), viewContainer.GetView<WeaponSpawnerView>());
        obstacleSpawnerPresenter = new ObstacleSpawnerPresenter(new ObstacleSpawnerModel(healthPresenter), viewContainer.GetView<ObstacleSpawnerView>());
        platformSpawnPresenter = new PlatformSpawnPresenter(new PlatformSpawnModel(platformPathGroup, obstacleSpawnerPresenter, trophySpawnerPresenter, zonePresenter, weaponSpawnerPresenter, coinSpawnerPresenter), viewContainer.GetView<PlatformSpawnView>());

        gameButtonsHiderPresenter = new GameButtonsHiderPresenter(new GameButtonsHiderModel(playerMovePresenter), viewContainer.GetView<GameButtonsHiderView>());

        animationElementPresenter = new AnimationElementPresenter(new AnimationElementModel(), viewContainer.GetView<AnimationElementView>());

        gameStateMachine = new GameStateMachine
            (sceneRoot, 
            zonePresenter, 
            healthPresenter, 
            cameraPresenter, 
            playerMovePresenter, 
            playerAnimationPresenter, 
            playerInputPresenter, 
            playerZoneActionPresenter, 
            playerColliderPresenter,
            obstacleSpawnerPresenter,
            storeWeaponPresenter,
            storeLevelPresenter,
            secondLevel,
            gameButtonsHiderPresenter,
            animationElementPresenter);

        sceneRoot.SetSoundProvider(soundPresenter);
        sceneRoot.Activate();

        ActivateEvents();

        soundPresenter.Initialize();
        particleEffectPresenter.Initialize();
        sceneRoot.Initialize();
        bankPresenter.Initialize();

        cameraPresenter.Initialize();

        storeLevelPresenter.Initialize();
        storeCollectionPresenter.Initialize();

        weaponGameVisualPresenter.Initialize();
        storeWeaponPresenter.Initialize();

        playerMovePresenter.Initialize();
        playerColliderPresenter.Initialize();
        playerInputPresenter.Initialize();
        playerDamageEffectPresenter.Initialize();
        playerAnimationPresenter.Initialize();
        playerZoneActionPresenter.Initialize();

        healthPresenter.Initialize();

        deadZonePresenter.Initialize();
        zonePresenter.Initialize();
        coinSpawnerPresenter.Initialize();
        trophySpawnerPresenter.Initialize();
        weaponSpawnerPresenter.Initialize();
        obstacleSpawnerPresenter.Initialize();
        platformSpawnPresenter.Initialize();
        platformSpawnPresenter.SpawnPlatforms();

        gameButtonsHiderPresenter.Initialize();

        storePlayerPresenter.Initialize();
        storeClothesPresenter.Initialize();

        animationElementPresenter.Initialize();

        gameStateMachine.Initialize();

        playerAnimationPresenter.Run();
    }

    private void ActivateEvents()
    {
        ActivateTransitions();
    }

    private void DeactivateEvents()
    {
        DeactivateTransitions();
    }

    private void ActivateTransitions()
    {
        sceneRoot.OnClickToExit_Header += HandleGoToMenu;
        sceneRoot.OnClickToExit_Lose += HandleGoToMenu;
        sceneRoot.OnClickToExit_Win += HandleGoToMenu;
    }

    private void DeactivateTransitions()
    {
        sceneRoot.OnClickToExit_Header -= HandleGoToMenu;
        sceneRoot.OnClickToExit_Lose -= HandleGoToMenu;
        sceneRoot.OnClickToExit_Win -= HandleGoToMenu;
    }

    private void Deactivate()
    {
        sceneRoot.Deactivate();
        soundPresenter?.Dispose();
    }

    private void Dispose()
    {
        DeactivateEvents();

        soundPresenter?.Dispose();
        sceneRoot?.Dispose();
        particleEffectPresenter?.Dispose();
        bankPresenter?.Dispose();

        storeLevelPresenter?.Dispose();
        storeCollectionPresenter?.Dispose();

        weaponGameVisualPresenter?.Dispose();
        storeWeaponPresenter?.Dispose();

        playerMovePresenter?.Dispose();
        playerColliderPresenter?.Dispose();
        playerInputPresenter?.Dispose();
        playerDamageEffectPresenter?.Dispose();
        playerAnimationPresenter?.Dispose();
        playerZoneActionPresenter?.Dispose();

        healthPresenter?.Dispose();

        cameraPresenter?.Dispose();

        deadZonePresenter?.Dispose();
        zonePresenter?.Dispose();
        coinSpawnerPresenter?.Dispose();
        trophySpawnerPresenter?.Dispose();
        weaponSpawnerPresenter?.Dispose();
        obstacleSpawnerPresenter?.Dispose();
        platformSpawnPresenter?.Dispose();

        gameButtonsHiderPresenter?.Dispose();

        storePlayerPresenter?.Dispose();
        storeClothesPresenter?.Dispose();

        animationElementPresenter?.Dispose();

        gameStateMachine?.Dispose();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            healthPresenter.AddHealth(2);
        }

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            playerMovePresenter.StopRun();
        }

        if (Input.GetKeyUp(KeyCode.LeftAlt))
        {
            playerMovePresenter.StartRun();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            healthPresenter.RemoveHealth(2);
        }
    }

    private void OnDestroy()
    {
        Dispose();
    }

    #region Output

    public event Action OnGoToMenu;

    private void HandleGoToMenu()
    {
        Deactivate();
        OnGoToMenu?.Invoke();
    }

    #endregion
}
