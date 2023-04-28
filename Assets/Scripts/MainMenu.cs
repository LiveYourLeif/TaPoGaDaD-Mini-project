using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public Animator animator;
    void Awake()
    {   
        DontDestroyOnLoad(this.gameObject);
    }

    //Method to start the game
    public void PlayGame()
    {
        animator.SetTrigger("FadeOut");
        //SceneManager.LoadScene("FightScene");
        
    }
    // Method to enter the settings
    public void EnterSettings()
    {
        SceneManager.LoadScene("Settings");
        
    }

    // Methhod to quit the game
    public void Quit()
    {
        Application.Quit();
    }
}
