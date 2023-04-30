using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class moveButtonUp : MonoBehaviour
{

    public Animator buttonAnim;
    public TextMeshProUGUI buttonText;
    
    public void animDoneWin()
    {
        buttonText.text = "Next Level!";
        buttonAnim.SetTrigger("MoveButtonUp");
    }
    public void animDoneLose()
    {
        buttonText.text = "Try Again?";
        buttonAnim.SetTrigger("MoveButtonUp");
    }
}
