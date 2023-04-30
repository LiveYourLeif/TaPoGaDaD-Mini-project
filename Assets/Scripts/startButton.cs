using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startButton : MonoBehaviour
{

    private musicManager music;
    private progress prog;
    private MainMenu mm;

    // Start is called before the first frame update
    void Start()
    {
        prog = GameObject.FindGameObjectWithTag("progress").GetComponent<progress>();
        music = GameObject.FindGameObjectWithTag("progress").GetComponent<musicManager>();
        mm = GameObject.FindGameObjectWithTag("scene").GetComponent<MainMenu>();
    }

    public void play()
    {
        prog.timer = 0;
        mm.PlayGame();
        music.fadeOut();
    }
}
