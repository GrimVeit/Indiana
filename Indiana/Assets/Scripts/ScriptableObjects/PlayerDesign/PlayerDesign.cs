using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Design", menuName = "Game/Clothes/Design")]
public class PlayerDesign : ScriptableObject
{
    public int ID => id;
    public List<Sprite> SpritesRun => spritesRun;
    public List<Sprite> SpritesJump => spritesJump;
    public List<Sprite> SpritesDie => spritesDie;
    public List<Sprite> SpritesHitPunch => spritesHitPunch;
    public List<Sprite> SpritesHitKnife => spritesHitKnife;
    public List<Sprite> SpritesHitWhip => spritesHitWhip;
    public List<Sprite> SpritesEndJump => spritesEndJump;

    [SerializeField] private int id;

    [SerializeField] private List<Sprite> spritesRun;
    [SerializeField] private List<Sprite> spritesJump;
    [SerializeField] private List<Sprite> spritesDie;
    [SerializeField] private List<Sprite> spritesHitPunch;
    [SerializeField] private List<Sprite> spritesHitKnife;
    [SerializeField] private List<Sprite> spritesHitWhip;
    [SerializeField] private List<Sprite> spritesEndJump;
}
