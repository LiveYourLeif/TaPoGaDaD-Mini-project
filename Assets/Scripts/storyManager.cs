using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class storyManager : MonoBehaviour
{
    int progress = 0;
    public GameObject Text1;
    public GameObject Text2;
    public Sprite newImage;
    public Animator animator;

    void Start()
    {
        animator = GameObject.FindWithTag("Fade").GetComponent<Animator>();
    }

    

    public void moveOn()
    {
        if(progress == 0)
        {
            progress++;
            Text1.SetActive(false);
            Text2.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("clickText"));
        }
        else if(progress == 1)
        {
            animator.SetTrigger("FadeOut");
        }
    }
}
