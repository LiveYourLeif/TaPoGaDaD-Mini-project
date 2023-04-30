using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sortingOrderChange : MonoBehaviour
{
    private Canvas c;
    private GameObject[] cards;
    private DragAndDrop DnD;

    private void Start()
    {
        c = GetComponentInParent<Canvas>();
        cards = GameObject.FindGameObjectsWithTag("Card");
    }

    public void setFront()
    {
        c.sortingOrder = 4;
        foreach (GameObject card in cards)
        {
            card.GetComponent<DragAndDrop>().dontMove = true;
        }
    }
}
