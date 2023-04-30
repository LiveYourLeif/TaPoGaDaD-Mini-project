using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playedCardSlot : MonoBehaviour
{
    public bool isFilled = false;
    [SerializeField]
    private int countCards = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Card" && other.gameObject.GetComponent<DragAndDrop>().isPlaced == true)
        {
            isFilled = true;
            other.gameObject.GetComponent<DragAndDrop>().assignedSlot = int.Parse(gameObject.name.Substring(5,1));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        countCards++;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        countCards--;
        if(countCards == 0)
        {
            isFilled = false;
        }
    }
}
