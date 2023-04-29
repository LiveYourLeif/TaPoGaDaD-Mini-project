using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class progress : MonoBehaviour
{
    public int currentLevel = 0;
    public Animator anim;
    public bool[] buttonStates = { true, true, true };
    void start()
    {

    }
    public void levelIncrease()
    {
        currentLevel++;
        print("level: " + currentLevel);
    }
}
