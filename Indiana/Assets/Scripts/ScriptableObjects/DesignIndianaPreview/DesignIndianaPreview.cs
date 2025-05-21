using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Design", menuName = "Game/Clothes/Preview/Design")]
public class DesignIndianaPreview : ScriptableObject
{
    public int Id => id;
    public Sprite SpriteDesign => spriteDesign;

    [SerializeField] private int id;
    [SerializeField] private Sprite spriteDesign;
}
