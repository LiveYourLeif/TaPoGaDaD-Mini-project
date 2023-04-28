using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transitionManager : MonoBehaviour
{
    public Animator animator;
    public Animator buttonAnimator;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        animator = GameObject.FindWithTag("Fade").GetComponent<Animator>();
    }

    public void AnimDone()
    {
        buttonAnimator.SetTrigger("MoveButtonUp");
    }

    public void playFootstep()
    {
        audioSource.Play();
    }

    public void moveOn()
    {
        animator.SetTrigger("FadeOut");
    }
}
