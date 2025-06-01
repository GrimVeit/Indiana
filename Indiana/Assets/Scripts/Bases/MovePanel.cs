using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePanel : Panel
{
    public bool IsActive => isActive;

    [SerializeField] protected Vector3 moveFrom;
    [SerializeField] protected Vector3 moveTo;
    [SerializeField] protected float time;
    [SerializeField] protected CanvasGroup canvasGroup;
    protected Tween tweenMove;

    private bool isActive;

    public override void ActivatePanel()
    {
        if (tweenMove != null) { tweenMove?.Kill(); }

        panel.SetActive(true);
        isActive = true;
        tweenMove = panel.transform.DOLocalMove(moveTo, time).OnComplete(() =>
        {
            OnActivatePanel?.Invoke();
            OnActivatePanel_Data?.Invoke(this);
        });
        CanvasGroupAlpha(canvasGroup, 0, 1, time);
    }

    public override void DeactivatePanel()
    {
        if (tweenMove != null) { tweenMove?.Kill(); }

        isActive = false;
        tweenMove = panel.transform.DOLocalMove(moveFrom, time).OnComplete(() => 
        {
            panel.SetActive(false);
            OnDeactivatePanel?.Invoke();
            OnDeactivatePanel_Data?.Invoke(this);
        });
        CanvasGroupAlpha(canvasGroup, 1, 0, time);
    }

    public override void Dispose()
    {
        base.Dispose();

        tweenMove?.Kill();
    }

    private void CanvasGroupAlpha(CanvasGroup canvasGroup, float from, float to, float time)
    {
        Coroutines.Start(SmoothVal(canvasGroup, from, to, time));
    }

    private IEnumerator SmoothVal(CanvasGroup canvasGroup, float from, float to, float timer)
    {
        float t = 0.0f;
        canvasGroup.alpha = from;

        while (t < 1.0f)
        {
            t += Time.deltaTime * (1.0f / timer);
            if (canvasGroup != null)
                canvasGroup.alpha = Mathf.Lerp(from, to, t);
            yield return 0;
        }
    }

    #region Input

    public event Action<MovePanel> OnDeactivatePanel_Data;
    public event Action<MovePanel> OnActivatePanel_Data;

    public event Action OnDeactivatePanel;
    public event Action OnActivatePanel;

    #endregion
}
