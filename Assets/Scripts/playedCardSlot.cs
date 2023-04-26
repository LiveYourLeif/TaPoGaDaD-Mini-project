using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playedCardSlot : MonoBehaviour
{
    public bool isFilled = false;
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
            print(gameObject.name.Substring(5,1));
            other.gameObject.GetComponent<DragAndDrop>().assignedSlot = int.Parse(gameObject.name.Substring(5,1));
        }
        else
        {
            isFilled = false;
        }
    }
}
