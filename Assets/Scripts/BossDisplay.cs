using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossDisplay : MonoBehaviour
{

    public BossClass boss;
    public TextMeshProUGUI bossName;
    public TextMeshProUGUI bossDescriptionText;

    public int scoreToBeat;

    public Image artWork;
    public Image animArtWork;
    public TextMeshProUGUI part1;
    public TextMeshProUGUI part2;
    public TextMeshProUGUI part3;
    public TextMeshProUGUI part4;

    void Start()
    {
        bossName.text = boss.newname;
        artWork.sprite = boss.bossDesign;
        animArtWork.sprite = boss.bossDesign;
        scoreToBeat = boss.targetScore;


        part1.text = boss.pcPart1;
        part2.text = boss.pcPart2;
        part3.text = boss.pcPart3;
        part4.text = boss.pcPart4;

    }

    void powerUp()
    {
        boss.pcPart1 = part1.text;
        boss.pcPart2 = part2.text;
        boss.pcPart3 = part3.text;
        boss.pcPart4 = part4.text;
    }
}

