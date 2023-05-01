using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playOneSound : MonoBehaviour
{
    private AudioSource aud;

    void Start()
    {
        aud = this.GetComponent<AudioSource>();
    }

    public void Play()
    {
        aud.Play();
    }
}
