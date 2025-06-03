using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameButtonsHiderView : View
{
    [SerializeField] private List<GameButton> gameButtonsMain = new();
    [SerializeField] private List<GameButton> gameButtonsOther = new();
    [SerializeField] private float durationWait;

    private IEnumerator timer;

    public void Show()
    {
        gameButtonsMain.Shuffle();

        if(timer != null) Coroutines.Stop(timer);

        timer = ShowCoro();
        Coroutines.Start(timer);
    }

    public void Hide()
    {
        gameButtonsMain.Shuffle();

        if (timer != null) Coroutines.Stop(timer);

        timer = HideCoro();
        Coroutines.Start(timer);
    }

    public void Show(int id)
    {
        var button = GetGameButtonWithId(id);

        if(button == null)
        {
            Debug.Log("Not found game button with id - " + id);
            return;
        }

        button.Show();
    }

    public void Hide(int id)
    {
        var button = GetGameButtonWithId(id);

        if (button == null)
        {
            Debug.Log("Not found game button with id - " + id);
            return;
        }

        button.Hide();
    }

    private GameButton GetGameButtonWithId(int id)
    {
        return gameButtonsOther.FirstOrDefault(data => data.Id == id);
    }

    private IEnumerator ShowCoro()
    {
        for (int i = 0; i < gameButtonsMain.Count; i++)
        {
            gameButtonsMain[i].Show();

            yield return new WaitForSeconds(durationWait);
        }
    }

    private IEnumerator HideCoro()
    {
        for (int i = 0; i < gameButtonsMain.Count; i++)
        {
            gameButtonsMain[i].Hide();

            yield return new WaitForSeconds(durationWait);
        }
    }
}
