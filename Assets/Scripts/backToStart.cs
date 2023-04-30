using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backToStart : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        animator = GameObject.FindWithTag("Fade").GetComponent<Animator>();
    }
    public void goToStart()
    {
        animator.SetTrigger("FadeOut");
    }
}
