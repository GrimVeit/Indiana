using System;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine;

public class MainMenuEntryPoint : MonoBehaviour
{
    [SerializeField] private Sounds sounds;
    [SerializeField] private ItemCollectionGroup itemCollectionGroup;
    [SerializeField] private WeaponGroup weaponGroup;
    [SerializeField] private DesignIndianaPreviewGroup designIndianaPreviewGroup;
    [SerializeField] private ClothesDesignGroup clothesDesignGroup;
    [SerializeField] private UIMainMenuRoot menuRootPrefab;

    private UIMainMenuRoot sceneRoot;
    private ViewContainer viewContainer;

    private BankPresenter bankPresenter;
    private ParticleEffectPresenter particleEffectPresenter;
    private SoundPresenter soundPresenter;

    private NicknameRandomPresenter nicknameRandomPresenter;
    private FirebaseAuthenticationPresenter firebaseAuthenticationPresenter;
    private FirebaseAuthenticationInfoPresenter firebaseAuthenticationInfoPresenter;
    private FirebaseDatabasePresenter firebaseDatabasePresenter;
    private InternetPresenter internetPresenter;

    private StoreCollectionPresenter storeCollectionPresenter;
    private CollectionVisualPresenter collectionVisualPresenter;

    private StoreWeaponPresenter storeWeaponPresenter;
    private WeaponMenuVisualPresenter weaponMenuVisualPresenter;

    private StoreClothesPresenter storeClothesPresenter;
    private IndianaPreviewInputPresenter indianaPreviewInputPresenter;
    private ClothesDragPresenter clothesDragPresenter;
    private IndianaDesignPreviewPresenter indianaDesignPreviewPresenter;

    private StoreLevelPresenter storeLevelPresenter;
    private LevelVisualPresenter levelVisualPresenter;
    private LevelPresenter levelPresenter;

    private AnimationElementPresenter animationElementPresenter;

    private MenuStateMachine stateMachine;

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


        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                FirebaseDatabase.DefaultInstance.SetPersistenceEnabled(false);
                FirebaseAuth firebaseAuth = FirebaseAuth.DefaultInstance;
                DatabaseReference databaseReference = FirebaseDatabase.DefaultInstance.RootReference;

                internetPresenter = new InternetPresenter(new InternetModel(), viewContainer.GetView<InternetView>());

                firebaseAuthenticationPresenter = new FirebaseAuthenticationPresenter
                    (new FirebaseAuthenticationModel(firebaseAuth, soundPresenter));

                firebaseDatabasePresenter = new FirebaseDatabasePresenter
                (new FirebaseDatabaseModel(firebaseAuth, databaseReference),
                viewContainer.GetView<FirebaseDatabaseView>());

                firebaseAuthenticationInfoPresenter = new FirebaseAuthenticationInfoPresenter
                (new FirebaseAuthenticationInfoModel(firebaseAuthenticationPresenter), 
                viewContainer.GetView<FirebaseAuthenticationInfoView>());

                nicknameRandomPresenter = new NicknameRandomPresenter(new NicknameRandomModel(), viewContainer.GetView<NicknameRandomView>());

                storeCollectionPresenter = new StoreCollectionPresenter(new StoreCollectionModel(itemCollectionGroup, PlayerPrefsKeys.RECORD));
                collectionVisualPresenter = new CollectionVisualPresenter(new CollectionVisualModel(storeCollectionPresenter), viewContainer.GetView<CollectionVisualView>());

                storeWeaponPresenter = new StoreWeaponPresenter(new StoreWeaponModel(weaponGroup));
                weaponMenuVisualPresenter = new WeaponMenuVisualPresenter(new WeaponMenuVisualModel(storeWeaponPresenter), viewContainer.GetView<WeaponMenuVisualView>());

                storeClothesPresenter = new StoreClothesPresenter(new StoreClothesModel(clothesDesignGroup));
                indianaPreviewInputPresenter = new IndianaPreviewInputPresenter(new IndianaPreviewInputModel(storeClothesPresenter), viewContainer.GetView<IndianaPreviewInputView>());
                clothesDragPresenter = new ClothesDragPresenter(new ClothesDragModel(soundPresenter), viewContainer.GetView<ClothesDragView>());
                indianaDesignPreviewPresenter = new IndianaDesignPreviewPresenter(new IndianaDesignPreviewModel(designIndianaPreviewGroup, storeClothesPresenter), viewContainer.GetView<IndianaDesignPreviewView>());

                storeLevelPresenter = new StoreLevelPresenter(new StoreLevelModel());
                levelVisualPresenter = new LevelVisualPresenter(new LevelVisualModel(storeLevelPresenter, storeLevelPresenter), viewContainer.GetView<LevelVisualView>());
                levelPresenter = new LevelPresenter(new LevelModel(storeLevelPresenter, soundPresenter), viewContainer.GetView<LevelView>());

                animationElementPresenter = new AnimationElementPresenter(new AnimationElementModel(), viewContainer.GetView<AnimationElementView>());

                stateMachine = new MenuStateMachine(sceneRoot, firebaseAuthenticationPresenter, firebaseDatabasePresenter, nicknameRandomPresenter, internetPresenter);

                sceneRoot.SetSoundProvider(soundPresenter);
                sceneRoot.Activate();

                ActivateEvents();

                soundPresenter.Initialize();
                particleEffectPresenter.Initialize();
                sceneRoot.Initialize();
                bankPresenter.Initialize();

                firebaseAuthenticationInfoPresenter.Initialize();
                internetPresenter.Initialize();
                nicknameRandomPresenter.Initialize();
                firebaseDatabasePresenter.Initialize();
                firebaseAuthenticationPresenter.Initialize();

                collectionVisualPresenter.Initialize();
                storeCollectionPresenter.Initialize();

                weaponMenuVisualPresenter.Initialize();
                storeWeaponPresenter.Initialize();

                clothesDragPresenter.Initialize();
                indianaDesignPreviewPresenter.Initialize();
                indianaPreviewInputPresenter.Initialize();
                storeClothesPresenter.Initialize();

                levelVisualPresenter.Initialize();
                levelPresenter.Initialize();
                storeLevelPresenter.Initialize();

                animationElementPresenter.Initialize();

                stateMachine.Initialize();
            }
            else
            {
                Debug.LogError(string.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });
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
        levelPresenter.OnActivate1Level += HandleGoToLevel1;
        levelPresenter.OnActivate2Level += HandleGoToLevel2;
        levelPresenter.OnActivate3Level += HandleGoToLevel3;
        levelPresenter.OnActivate4Level += HandleGoToLevel4;
    }

    private void DeactivateTransitions()
    {
        levelPresenter.OnActivate1Level -= HandleGoToLevel1;
        levelPresenter.OnActivate2Level -= HandleGoToLevel2;
        levelPresenter.OnActivate3Level -= HandleGoToLevel3;
        levelPresenter.OnActivate4Level -= HandleGoToLevel4;
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

            firebaseAuthenticationInfoPresenter.Dispose();
            internetPresenter.Dispose();
            nicknameRandomPresenter.Dispose();
            firebaseDatabasePresenter.Dispose();
            firebaseAuthenticationPresenter.Dispose();

            collectionVisualPresenter.Dispose();
            storeCollectionPresenter.Dispose();

            weaponMenuVisualPresenter.Dispose();
            storeWeaponPresenter.Dispose();

            clothesDragPresenter.Dispose();
            indianaDesignPreviewPresenter.Dispose();
            indianaPreviewInputPresenter.Dispose();
            storeClothesPresenter.Dispose();

            levelVisualPresenter.Dispose();
            levelPresenter.Dispose();
            storeLevelPresenter.Dispose();

            animationElementPresenter.Dispose();

            stateMachine.Dispose();
        }
    }

    private void OnDestroy()
    {
        Dispose();
    }

    #region Output

    public event Action OnGoToLevel1;
    public event Action OnGoToLevel2;
    public event Action OnGoToLevel3;
    public event Action OnGoToLevel4;

    private void HandleGoToLevel1()
    {
        Deactivate();
        OnGoToLevel1?.Invoke();
    }

    private void HandleGoToLevel2()
    {
        Deactivate();
        OnGoToLevel2?.Invoke();
    }

    private void HandleGoToLevel3()
    {
        Deactivate();
        OnGoToLevel3?.Invoke();
    }

    private void HandleGoToLevel4()
    {
        Deactivate();
        OnGoToLevel4?.Invoke();
    }

    #endregion
}
