using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findMusic : MonoBehaviour
{
    public musicManager mm;

    private void Start()
    {
        mm = GameObject.FindGameObjectWithTag("progress").GetComponent<musicManager>();
    }

    public void buttonPress()
    {
        mm.fadeOut();
        print("fadeing out");
    }
       
}
