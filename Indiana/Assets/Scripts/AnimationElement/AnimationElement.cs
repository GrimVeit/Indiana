using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AnimationElement : MonoBehaviour
{
    public string Id => id;

    [SerializeField] private protected string id;
    [SerializeField] private protected Transform element;

    public virtual void Initialize() { }
    public virtual void Dispose() { }

    public abstract void Animate();
}
