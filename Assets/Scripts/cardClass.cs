using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new card", menuName ="Card")]
public class cardClass : ScriptableObject
{
    public string newname;
    public string description;

    public Sprite cardDesign;

    public string computerPart1;
    public string computerPart2;
    public string computerPart3;
    public int computerPartPoint1;
    public int computerPartPoint2;
    public int computerPartPoint3;
}
