using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new category", menuName ="Category")]
public class CategoryClass : ScriptableObject
{
    [TextArea(2,2)]
    public string category;
    [TextArea(10,5)]
    public string description;
    public int conditionType;

    // m = "modifer"
}
