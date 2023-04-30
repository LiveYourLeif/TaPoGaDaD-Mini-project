using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class progress : MonoBehaviour
{
    public int currentLevel = 0;
    public Animator anim;
    public bool[] buttonStates = { true, true, true };
    public bool forcedQuit = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            buttonStates[0] = true;
            buttonStates[1] = true;
            buttonStates[2] = true;
            SceneManager.LoadScene("MainMenu");
        }
    }

public void levelIncrease()
    {
        currentLevel++;
        print("level: " + currentLevel);
    }
}
