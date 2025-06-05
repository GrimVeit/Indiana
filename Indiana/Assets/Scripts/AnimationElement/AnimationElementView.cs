using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AnimationElementView : View
{
    [SerializeField] private List<AnimationElement> animationElements = new();

    public void Initialize()
    {
        animationElements.ForEach(data => data.Initialize());
    }

    public void Dispose()
    {
        animationElements.ForEach(data => data.Dispose());
    }

    public void Animate(string id)
    {
        var element = GetAnimationElement(id);

        if(element == null)
        {
            Debug.LogWarning("Not found animation with id - " + id);
            return;
        } 

        element.Animate();
    }

    private AnimationElement GetAnimationElement(string id)
    {
        return animationElements.FirstOrDefault(data => data.Id == id);
    }
}
