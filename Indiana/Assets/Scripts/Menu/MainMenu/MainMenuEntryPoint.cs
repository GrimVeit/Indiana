using System;
using System.Collections;
using UnityEngine;

public class MainMenuEntryPoint : MonoBehaviour
{
    [SerializeField] private Sounds sounds;
    [SerializeField] private ItemCollectionGroup itemCollectionGroup;
    [SerializeField] private DesignIndianaPreviewGroup designIndianaPreviewGroup;
    [SerializeField] private ClothesDesignGroup clothesDesignGroup;
    [SerializeField] private UIMainMenuRoot menuRootPrefab;

    private UIMainMenuRoot sceneRoot;
    private ViewContainer viewContainer;

    private BankPresenter bankPresenter;
    private ParticleEffectPresenter particleEffectPresenter;
    private SoundPresenter soundPresenter;

    private StoreCollectionPresenter storeCollectionPresenter;
    private CollectionVisualPresenter collectionVisualPresenter;

    private StoreClothesPresenter storeClothesPresenter;
    private IndianaPreviewInputPresenter indianaPreviewInputPresenter;
    private ClothesDragPresenter clothesDragPresenter;
    private IndianaDesignPreviewPresenter indianaDesignPreviewPresenter;

    private bool isSceneActive = false;

    public void Run(UIRootView uIRootView)
    {
        isSceneActive = true;

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

        storeCollectionPresenter = new StoreCollectionPresenter(new StoreCollectionModel(itemCollectionGroup));
        collectionVisualPresenter = new CollectionVisualPresenter(new CollectionVisualModel(storeCollectionPresenter), viewContainer.GetView<CollectionVisualView>());

        storeClothesPresenter = new StoreClothesPresenter(new StoreClothesModel(clothesDesignGroup));
        indianaPreviewInputPresenter = new IndianaPreviewInputPresenter(new IndianaPreviewInputModel(storeClothesPresenter), viewContainer.GetView<IndianaPreviewInputView>());
        clothesDragPresenter = new ClothesDragPresenter(new ClothesDragModel(soundPresenter), viewContainer.GetView<ClothesDragView>());
        indianaDesignPreviewPresenter = new IndianaDesignPreviewPresenter(new IndianaDesignPreviewModel(designIndianaPreviewGroup, storeClothesPresenter), viewContainer.GetView<IndianaDesignPreviewView>());

        sceneRoot.SetSoundProvider(soundPresenter);
        sceneRoot.Activate();

        ActivateEvents();

        soundPresenter.Initialize();
        particleEffectPresenter.Initialize();
        sceneRoot.Initialize();
        bankPresenter.Initialize();
    }

    private void ActivateEvents()
    {
        ActivateTransitions();

        collectionVisualPresenter.Initialize();
        storeCollectionPresenter.Initialize();

        clothesDragPresenter.Initialize();
        indianaDesignPreviewPresenter.Initialize();
        indianaPreviewInputPresenter.Initialize();
        storeClothesPresenter.Initialize();
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
        if (isSceneActive)
        {
            DeactivateEvents();

            soundPresenter.Dispose();
            sceneRoot.Dispose();
            particleEffectPresenter.Dispose();
            bankPresenter?.Dispose();

            collectionVisualPresenter.Dispose();
            storeCollectionPresenter.Dispose();

            clothesDragPresenter.Dispose();
            indianaDesignPreviewPresenter.Dispose();
            indianaPreviewInputPresenter.Dispose();
            storeClothesPresenter.Dispose();
        }
    }

    private void OnDestroy()
    {
        Dispose();
    }

    #region Output

    public event Action OnGoToGame;

    private void HandleGoToGame()
    {
        Deactivate();
        OnGoToGame?.Invoke();
    }

    #endregion
}
