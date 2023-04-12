using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new boss", menuName ="Boss")]
public class BossClass : ScriptableObject
{
    public string newname;
    public string description;
    public Sprite bossDesign;
    public int targetScore;

    public string pcPart1;
    public string pcPart2;
    public string pcPart3;
    public string pcPart4;
}