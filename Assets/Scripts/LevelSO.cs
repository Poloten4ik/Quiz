using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "lvl", fileName = " new level")]
public class LevelSO : ScriptableObject
{
    [TextArea(10,30)]
    public string question;
    public string[] variant;
    public Sprite Bg;
    public LevelSO nextLevel;
    public int rightVariant;
}
