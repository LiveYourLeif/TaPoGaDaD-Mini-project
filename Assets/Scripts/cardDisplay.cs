using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class cardDisplay : MonoBehaviour
{

    public cardClass card_class;

    public Image artworkImageOfCard;
    public TextMeshProUGUI part1;
    public TextMeshProUGUI part2;
    public TextMeshProUGUI part3;
    public TextMeshProUGUI point1;
    public TextMeshProUGUI point2;
    public TextMeshProUGUI point3;


    void Start()
    {
        artworkImageOfCard.sprite = card_class.cardDesign;
    }


}
