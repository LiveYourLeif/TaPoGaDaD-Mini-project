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
    public float timer = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }

        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            buttonStates[0] = true;
            buttonStates[1] = true;
            buttonStates[2] = true;
            currentLevel = 0;
        }
        timer += Time.deltaTime;
    }

    public void levelIncrease()
    {
        currentLevel++;
        print("level: " + currentLevel);
    }
}
