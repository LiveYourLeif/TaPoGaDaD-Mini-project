using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class getTime : MonoBehaviour
{
    private progress prog;
    private TextMeshProUGUI timerText;
    float minutes;
    float seconds;
    void Start()
    {
        prog = GameObject.FindGameObjectWithTag("progress").GetComponent<progress>();
        timerText = this.GetComponent<TextMeshProUGUI>();

        minutes = Mathf.Floor(prog.timer / 60);
        seconds = Mathf.Floor(prog.timer % 60);

        timerText.text = "Time: " + minutes + " minutes & " + seconds + " seconds";
    }
}
