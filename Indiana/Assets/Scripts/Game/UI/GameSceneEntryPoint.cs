using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneEntryPoint : MonoBehaviour
{
    [SerializeField] private Sounds sounds;
    [SerializeField] private PlatformPathGroup platformPathGroup;
    [SerializeField] private UIGameSceneRoot_Game menuRootPrefab;

    private UIGameSceneRoot_Game sceneRoot;
    private ViewContainer viewContainer;

    private BankPresenter bankPresenter;
    private ParticleEffectPresenter particleEffectPresenter;
    private SoundPresenter soundPresenter;

    private PlatformSpawnPresenter platformSpawnPresenter;

    private CameraPresenter cameraPresenter;

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

        platformSpawnPresenter = new PlatformSpawnPresenter(new PlatformSpawnModel(platformPathGroup), viewContainer.GetView<PlatformSpawnView>());

        cameraPresenter = new CameraPresenter(new CameraModel(), viewContainer.GetView<CameraView>());

        sceneRoot.SetSoundProvider(soundPresenter);
        sceneRoot.Activate();

        ActivateEvents();

        soundPresenter.Initialize();
        particleEffectPresenter.Initialize();
        sceneRoot.Initialize();
        bankPresenter.Initialize();

        cameraPresenter.Initialize();

        platformSpawnPresenter.Initialize();
        platformSpawnPresenter.SpawnPlatforms();
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

        cameraPresenter?.Dispose();
        platformSpawnPresenter?.Dispose();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            cameraPresenter.ActivateLookAt();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            cameraPresenter.DeactivateLookAt();
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
