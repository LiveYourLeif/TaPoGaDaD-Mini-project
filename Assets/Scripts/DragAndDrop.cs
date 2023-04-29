using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Vector3 _dragOffset;
    private Camera _cam;
    public int assignedSlot;
    [SerializeField] private Transform dropPos;
    public GameObject tempObject;
    public bool isPlaced = false;

    void Start()
    {
        dropPos = this.gameObject.transform;
    }
    
    void OnMouseDown()
    {
        _dragOffset = transform.position - GetMousePos();
        isPlaced = false;

        Canvas canvasRenderer = GetComponentInChildren<Canvas>();

        int highestSortingOrder = 0;
        foreach (GameObject card in GameObject.FindGameObjectsWithTag("Card"))
        {
            Canvas otherCanvasRenderer = card.GetComponentInChildren<Canvas>();
            if (otherCanvasRenderer.sortingLayerID == canvasRenderer.sortingLayerID && otherCanvasRenderer.sortingOrder > highestSortingOrder)
            {
                highestSortingOrder = otherCanvasRenderer.sortingOrder;
            }
        }

        canvasRenderer.sortingLayerID = SortingLayer.NameToID("Default");
        canvasRenderer.sortingOrder = highestSortingOrder + 1;

        transform.SetAsLastSibling();
    }

    void OnMouseDrag()
    {
        transform.position = GetMousePos();
    } 

    void OnMouseUp()
    {
        this.gameObject.transform.position = dropPos.position;
        isPlaced = true;
    }

    Vector3 GetMousePos()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = -1;
        return mousePos;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "PlayCardSlot" && other.gameObject.GetComponent<playedCardSlot>().isFilled == false)
        {
            dropPos = other.gameObject.transform;
            tempObject = other.gameObject;
        }
    }

    void OnTriggerExit2D()
    {
        dropPos = this.gameObject.transform;
    }
}
