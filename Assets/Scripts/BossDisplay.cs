using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossDisplay : MonoBehaviour
{

    public ClientClass boss;
    public TextMeshProUGUI bossName;
    public TextMeshProUGUI bossDescriptionText;

    public TextMeshProUGUI scoreToBeat;

    public Image artworkImageOfBoss;
    public TextMeshProUGUI part1;
    public TextMeshProUGUI part2;
    public TextMeshProUGUI part3;
    public TextMeshProUGUI part4;

    void Start()
    {
        bossName.text = boss.newname;
        bossDescriptionText.text = boss.description;
        //artworkImageOfBoss.sprite = boss.bossDesign;
        scoreToBeat.text = "TARGET SCORE: " + boss.targetScore.ToString();

        part1.text = boss.pcPart1;
        part2.text = boss.pcPart2;
        part3.text = boss.pcPart3;
        part4.text = boss.pcPart4;

    }


}

