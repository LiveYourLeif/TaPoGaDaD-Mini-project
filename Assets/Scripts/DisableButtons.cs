using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableButtons : MonoBehaviour
{
    public progress prog;
    void Start()
    {
        prog = GameObject.FindGameObjectWithTag("progress").GetComponent<progress>();

        if(this.name == "Shuffle" && prog.buttonStates[0] == false)
        {
            Disable();
        }
        else if (this.name == "Category Reroll" && prog.buttonStates[1] == false)
        {
            Disable();
        }
        else if (this.name == "Parts Reroll" && prog.buttonStates[2] == false)
        {
            Disable();
        }
    }
    public void Disable()
    {
        this.gameObject.GetComponent<Button>().interactable = false;
    }
}
