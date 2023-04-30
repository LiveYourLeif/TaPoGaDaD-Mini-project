using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fadeInAnimator : MonoBehaviour
{

    public Animator animator;
    public Animator levelAnimator;
    public progress p;
    private int level;
    // Update is called once per frame
    void Start()
    {
        p = GameObject.FindGameObjectWithTag("progress").GetComponent<progress>();
    }
    public void FadeToLevel (int LevelIndex)
    {
        animator.SetTrigger("FadeOut");
    }

        public void OnFadeComplete()
    {
        if(SceneManager.GetActiveScene().name == "Victory")
        {
            p.currentLevel = 0;
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            if (SceneManager.GetActiveScene().buildIndex < 3)
                if (p.currentLevel == 4)
                {
                    SceneManager.LoadScene("Victory");
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
        }
        animator.SetTrigger("FadeIn");
    }
}
