using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fadeInAnimator : MonoBehaviour
{

    public Animator animator;
    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeToLevel (int LevelIndex)
    {
        animator.SetTrigger("FadeOut");
    }

        public void OnFadeComplete()
    {
        SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
        animator.SetTrigger("FadeIn");
    }
}
