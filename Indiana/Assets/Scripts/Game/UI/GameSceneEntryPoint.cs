using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneEntryPoint : MonoBehaviour
{
    [SerializeField] private Sounds sounds;
    [SerializeField] private ClothesDesignGroup clothesDesignGroup;
    [SerializeField] private PlayerDesignGroup playerDesignGroup;
    [SerializeField] private PlatformPathGroup platformPathGroup;
    [SerializeField] private UIGameSceneRoot_Game menuRootPrefab;

    private UIGameSceneRoot_Game sceneRoot;
    private ViewContainer viewContainer;

    private BankPresenter bankPresenter;
    private ParticleEffectPresenter particleEffectPresenter;
    private SoundPresenter soundPresenter;

    private StoreClothesPresenter storeClothesPresenter;
    private StorePlayerPresenter storePlayerPresenter;

    private PlatformSpawnPresenter platformSpawnPresenter;
    private ObstacleSpawnerPresenter obstacleSpawnerPresenter;
    private TrophySpawnerPresenter trophySpawnerPresenter;

    private HealthPresenter healthPresenter;

    private PlayerDamageEffectPresenter playerDamageEffectPresenter;
    private PlayerMovePresenter playerMovePresenter;
    private PlayerInputPresenter playerInputPresenter;
    private PlayerAnimationPresenter playerAnimationPresenter;

    private ZonePresenter zonePresenter;
    private DeadZonePresenter deadZonePresenter;

    private CameraPresenter cameraPresenter;

    private GameStateMachine gameStateMachine;

    private void Start()
    {
        Run();
    }

    public void Run()
    {
        sceneRoot = menuRootPrefab;

        //uIRootView.AttachSceneUI(sceneRoot.gameObject, Camera.main);

        viewContainer = sceneRoot.GetComponent<ViewContainer>();
        viewContainer.Initialize();

        soundPresenter = new SoundPresenter
            (new SoundModel(sounds.sounds, PlayerPrefsKeys.IS_MUTE_SOUNDS),
            viewContainer.GetView<SoundView>());

        particleEffectPresenter = new ParticleEffectPresenter
            (new ParticleEffectModel(),
            viewContainer.GetView<ParticleEffectView>());

        bankPresenter = new BankPresenter(new BankModel(), viewContainer.GetView<BankView>());

        storeClothesPresenter = new StoreClothesPresenter(new StoreClothesModel(clothesDesignGroup));
        storePlayerPresenter = new StorePlayerPresenter(new StorePlayerModel(storeClothesPresenter, playerDesignGroup));

        playerMovePresenter = new PlayerMovePresenter(new PlayerMoveModel(), viewContainer.GetView<PlayerMoveView>());
        playerAnimationPresenter = new PlayerAnimationPresenter(new PlayerAnimationModel(storePlayerPresenter, playerMovePresenter), viewContainer.GetView<PlayerAnimationView>());
        playerInputPresenter = new PlayerInputPresenter(new PlayerInputModel(playerMovePresenter, playerAnimationPresenter), viewContainer.GetView<PlayerInputView>());
        playerDamageEffectPresenter = new PlayerDamageEffectPresenter(new PlayerDamageEffectModel(), viewContainer.GetView<PlayerDamageEffectView>());
        healthPresenter = new HealthPresenter(new HealthModel(5, playerDamageEffectPresenter), viewContainer.GetView<HealthView>());

        cameraPresenter = new CameraPresenter(new CameraModel(), viewContainer.GetView<CameraView>());

        deadZonePresenter = new DeadZonePresenter(new DeadZoneModel(healthPresenter), viewContainer.GetView<DeadZoneView>());
        zonePresenter = new ZonePresenter(new ZoneModel(cameraPresenter), viewContainer.GetView<ZoneView>());
        trophySpawnerPresenter = new TrophySpawnerPresenter(new TrophySpawnerModel(), viewContainer.GetView<TrophySpawnerView>());
        obstacleSpawnerPresenter = new ObstacleSpawnerPresenter(new ObstacleSpawnerModel(healthPresenter), viewContainer.GetView<ObstacleSpawnerView>());
        platformSpawnPresenter = new PlatformSpawnPresenter(new PlatformSpawnModel(platformPathGroup, obstacleSpawnerPresenter, trophySpawnerPresenter, zonePresenter), viewContainer.GetView<PlatformSpawnView>());

        gameStateMachine = new GameStateMachine(sceneRoot, zonePresenter, healthPresenter, cameraPresenter, playerMovePresenter, playerAnimationPresenter, playerInputPresenter);

        sceneRoot.SetSoundProvider(soundPresenter);
        sceneRoot.Activate();

        ActivateEvents();

        soundPresenter.Initialize();
        particleEffectPresenter.Initialize();
        sceneRoot.Initialize();
        bankPresenter.Initialize();

        cameraPresenter.Initialize();

        playerMovePresenter.Initialize();
        playerInputPresenter.Initialize();
        playerDamageEffectPresenter.Initialize();
        playerAnimationPresenter.Initialize();

        healthPresenter.Initialize();

        deadZonePresenter.Initialize();
        zonePresenter.Initialize();
        trophySpawnerPresenter.Initialize();
        obstacleSpawnerPresenter.Initialize();
        platformSpawnPresenter.Initialize();
        platformSpawnPresenter.SpawnPlatforms();

        storePlayerPresenter.Initialize();
        storeClothesPresenter.Initialize();

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

    }

    private void DeactivateTransitions()
    {

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

        playerMovePresenter?.Dispose();
        playerInputPresenter?.Dispose();
        playerDamageEffectPresenter?.Dispose();

        healthPresenter?.Dispose();

        cameraPresenter?.Dispose();

        deadZonePresenter?.Dispose();
        zonePresenter?.Dispose();
        trophySpawnerPresenter?.Dispose();
        obstacleSpawnerPresenter?.Dispose();
        platformSpawnPresenter?.Dispose();

        storePlayerPresenter?.Dispose();
        storeClothesPresenter?.Dispose();

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
