using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class announcerSounds : MonoBehaviour
{

    public AudioClip a_mette;
    public AudioClip a_bunger;
    public AudioClip a_harold;
    public AudioClip a_roy;
    public AudioClip a_drama;

    public AudioSource announcer;
    public AudioSource drama;

    public progress prog;

    void Start()
    {
        prog = GameObject.FindGameObjectWithTag("progress").GetComponent<progress>();
    }
    public void playDrama()
    {
        drama.Play();
    }

    public void announceClient()
    {
        switch (prog.currentLevel)
        {
            case 0:
                announcer.clip = a_mette;
                break;
            case 1:
                announcer.clip = a_bunger;
                break;
            case 2:
                announcer.clip = a_harold;
                break;
            case 3:
                announcer.clip = a_roy;
                break;
        }
        announcer.Play();
    }
}
