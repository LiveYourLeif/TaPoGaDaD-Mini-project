using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Vector3 _dragOffset;
    private Camera _cam;
    private bool checkCollision = false;
    public int assignedSlot;
    [SerializeField] private Transform dropPos;
    
    void OnMouseDown()
    {
        _dragOffset = transform.position - GetMousePos();
    }

    void OnMouseDrag()
    {
        transform.position = GetMousePos() + _dragOffset;
    } 

    void OnMouseUp()
    {
        this.gameObject.transform.position = dropPos.position;
    }

    Vector3 GetMousePos()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "PlayCardSlot")
        {
            dropPos = other.gameObject.transform;
            assignedSlot = 1;
        }
        else if(other.gameObject.tag == "PlayCardSlot2")
        {
            dropPos = other.gameObject.transform;
            assignedSlot = 2;
        }
        else if(other.gameObject.tag == "PlayCardSlot3")
        {
            dropPos = other.gameObject.transform;
            assignedSlot = 3;
        }
        else if(other.gameObject.tag == "PlayCardSlot4")
        {
            dropPos = other.gameObject.transform;
            assignedSlot = 4;
        }
    }

    void OnTriggerExit2D()
    {
        dropPos = this.gameObject.transform;
    }
}
