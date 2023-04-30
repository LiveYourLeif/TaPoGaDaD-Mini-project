using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fightEndPlaySound : MonoBehaviour
{
    public AudioSource good;
    public AudioSource bad;

    public void playGood()
    {
        good.Play();
    }
    public void playBad()
    {
        bad.Play();
    }
}
