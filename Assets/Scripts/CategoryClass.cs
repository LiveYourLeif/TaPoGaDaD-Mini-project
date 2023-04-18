using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new category", menuName ="Category")]
public class CategoryClass : ScriptableObject
{
    public string category;
    [TextArea(15,5)]
    public string description;
    public bool conditionMet;

    // m = "modifer"
    public int m_CPU;
    public int m_Power;
    public int m_Cooler;
    public int m_Case;
    public int m_Mouse;
    public int m_Keyboard;
    public int m_Monitor;
    public int m_Speaker;
}
