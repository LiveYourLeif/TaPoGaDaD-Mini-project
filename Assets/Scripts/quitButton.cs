using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitButton : MonoBehaviour
{
    private MainMenu mm;

    // Start is called before the first frame update
    void Start()
    {
        mm = GameObject.FindGameObjectWithTag("scene").GetComponent<MainMenu>();
    }

    public void quit()
    {
        mm.Quit();
    }
}
