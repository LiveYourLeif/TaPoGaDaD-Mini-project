using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundFXPlayer : MonoBehaviour
{
    private AudioSource audSrc;

    private void Start()
    {
        audSrc = this.GetComponent<AudioSource>();
    }

    public void playSound()
    {
        audSrc.Play();
    }
}
