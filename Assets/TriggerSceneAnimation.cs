using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TriggerSceneAnimation : MonoBehaviour
{
    public string nameofSceneToSwitchTo;
    public Renderer renderer;
    public Animator animator;
    public void StartAnimation(){
        renderer.enabled = true;
        animator.SetTrigger("Play");
        Invoke(nameof(ChangeScene),0.5f);
    }
    private void ChangeScene(){
        SceneManager.LoadScene(nameofSceneToSwitchTo);
    }
}
