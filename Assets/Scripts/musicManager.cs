using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class musicManager : MonoBehaviour
{
    public AudioSource goofy;
    public AudioSource positiveLoop;
    public AudioSource fightTheme;
    public AudioSource lil8bit;

    public AudioSource[] audSrc = new AudioSource[3];

    public bool fadingOut = false;
    public bool noLoop = false;

    void Start()
    {
        audSrc[0] = goofy;
        audSrc[1] = positiveLoop;
        audSrc[2] = fightTheme;
        audSrc[3] = lil8bit;
    }

    // Update is called once per frame
    void Update()
    {
        if ((SceneManager.GetActiveScene().name == "LevelTransition0" || SceneManager.GetActiveScene().name == "Story") && positiveLoop.isPlaying == false)
        {
            goofy.volume = 0.3f;
            fightTheme.volume = 0.3f;
            goofy.Stop();
            fightTheme.Stop();
            lil8bit.Stop();
            positiveLoop.Play();
        }
        else if (SceneManager.GetActiveScene().name == "MainMenu" && goofy.isPlaying == false)
        {
            lil8bit.volume = 0.3f;
            goofy.Play();
            fightTheme.Stop();
            lil8bit.Stop();
            positiveLoop.Stop();
        }
        else if (SceneManager.GetActiveScene().name == "FightScene" && fightTheme.isPlaying == false)
        {
            positiveLoop.volume = 0.3f;
            goofy.Stop();
            fightTheme.Play();
            lil8bit.Stop();
            positiveLoop.Stop();
        }
        else if (SceneManager.GetActiveScene().name == "Victory" && lil8bit.isPlaying == false)
        {
            positiveLoop.volume = 0.3f;
            goofy.Stop();
            fightTheme.Stop();
            lil8bit.Play();
            positiveLoop.Stop();
        }


    // Fadeout

    foreach (AudioSource a in audSrc)
        {
            if (fadingOut == true)
            {
                if (a.isPlaying == true && a.volume > 0)
                {
                    a.volume -= Time.deltaTime / 4;
                }
                else if (a.isPlaying == true && a.volume <= 0)
                {
                    a.Stop();
                    fadingOut = false;
                }
            }

        }

    }

    public void fadeOut()
    {
        fadingOut = true;
    }
}
