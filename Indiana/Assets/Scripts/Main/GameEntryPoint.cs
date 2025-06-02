using System.Collections;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEntryPoint
{
    private static GameEntryPoint instance;
    private UIRootView rootView;
    private Coroutines coroutines;
    public GameEntryPoint()
    {
        coroutines = new GameObject("[Coroutines]").AddComponent<Coroutines>();
        Object.DontDestroyOnLoad(coroutines.gameObject);

        var prefabUIRoot = Resources.Load<UIRootView>("UIRootView");
        rootView = Object.Instantiate(prefabUIRoot);
        Object.DontDestroyOnLoad(rootView.gameObject);

    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Autorun()
    {
        GlobalGameSettings();

        instance = new GameEntryPoint();
        instance.Run();

    }

    private static void GlobalGameSettings()
    {
        Application.targetFrameRate = 60;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    private void Run()
    {
        coroutines.StartCoroutine(LoadAndStartMainMenu());
    }

    private IEnumerator LoadAndStartMainMenu()
    {
        yield return rootView.ShowLoadingScreen(0);

        yield return LoadScene(Scenes.BOOT);
        yield return LoadScene(Scenes.MAIN_MENU);

        yield return new WaitForEndOfFrame();

        var sceneEntryPoint = Object.FindObjectOfType<MainMenuEntryPoint>();

        sceneEntryPoint.Run(rootView);

        sceneEntryPoint.OnGoToLevel1 += () => coroutines.StartCoroutine(LoadAndStartGameScene_Level1());
        sceneEntryPoint.OnGoToLevel2 += () => coroutines.StartCoroutine(LoadAndStartGameScene_Level2());
        sceneEntryPoint.OnGoToLevel3 += () => coroutines.StartCoroutine(LoadAndStartGameScene_Level3());
        sceneEntryPoint.OnGoToLevel4 += () => coroutines.StartCoroutine(LoadAndStartGameScene_Level4());

        yield return rootView.HideLoadingScreen(0);
    }

    private IEnumerator LoadAndStartGameScene_Level1()
    {
        yield return rootView.ShowLoadingScreen(1);

        yield return LoadScene(Scenes.BOOT);
        yield return LoadScene(Scenes.GAME_LEVEL1);

        yield return new WaitForEndOfFrame();

        var sceneEntryPoint = Object.FindObjectOfType<GameSceneEntryPoint>();
        sceneEntryPoint.Run(rootView);

        sceneEntryPoint.OnGoToMenu += () => coroutines.StartCoroutine(LoadAndStartMainMenu());

        yield return rootView.HideLoadingScreen(1);
    }

    private IEnumerator LoadAndStartGameScene_Level2()
    {
        yield return rootView.ShowLoadingScreen(2);

        yield return LoadScene(Scenes.BOOT);
        yield return LoadScene(Scenes.GAME_LEVEL2);

        yield return new WaitForEndOfFrame();

        var sceneEntryPoint = Object.FindObjectOfType<GameSceneEntryPoint>();
        sceneEntryPoint.Run(rootView);

        sceneEntryPoint.OnGoToMenu += () => coroutines.StartCoroutine(LoadAndStartMainMenu());

        yield return rootView.HideLoadingScreen(2);
    }

    private IEnumerator LoadAndStartGameScene_Level3()
    {
        yield return rootView.ShowLoadingScreen(3);

        yield return LoadScene(Scenes.BOOT);
        yield return LoadScene(Scenes.GAME_LEVEL3);

        yield return new WaitForEndOfFrame();

        var sceneEntryPoint = Object.FindObjectOfType<GameSceneEntryPoint>();
        sceneEntryPoint.Run(rootView);

        sceneEntryPoint.OnGoToMenu += () => coroutines.StartCoroutine(LoadAndStartMainMenu());

        yield return rootView.HideLoadingScreen(3);
    }

    private IEnumerator LoadAndStartGameScene_Level4()
    {
        yield return rootView.ShowLoadingScreen(4);

        yield return LoadScene(Scenes.BOOT);
        yield return LoadScene(Scenes.GAME_LEVEL4);

        yield return new WaitForEndOfFrame();

        var sceneEntryPoint = Object.FindObjectOfType<GameSceneEntryPoint>();
        sceneEntryPoint.Run(rootView);

        sceneEntryPoint.OnGoToMenu += () => coroutines.StartCoroutine(LoadAndStartMainMenu());

        yield return rootView.HideLoadingScreen(4);
    }

    private IEnumerator LoadScene(string scene)
    {
        Debug.Log("Загрузка сцены - " + scene);
        yield return SceneManager.LoadSceneAsync(scene);
    }
}
