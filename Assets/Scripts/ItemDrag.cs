using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //Check current item in slot
    public DropSlot currentSlot;

    //Canvas for the item/card(s)
    public Canvas canvas;

    //UI Raycaster
    public GraphicRaycaster raycaster;

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Reference to the canvas and raycaster
        canvas = GetComponent<Canvas>();
        raycaster = canvas.GetComponent<GraphicRaycaster>();

        //Move card(s) with correct scaling
        transform.localPosition += new Vector3(eventData.delta.x, eventData.delta.y, 0) / transform.lossyScale.x;

        //Set parent-relative position, scale and rotation to keep its local orientation rathan than global orientation 
        transform.SetParent(canvas.transform, true);
        //Move the transform to the end of the local transform list, aka. last child to be rendered on top
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.localPosition += new Vector3(eventData.delta.x, eventData.delta.y, 0) / transform.lossyScale.x;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        var result = new List<RaycastResult>();
        raycaster.Raycast(eventData, result);

        foreach (var hit in result)
        {
            var slot = hit.gameObject.GetComponent<DropSlot>();
            if (slot)
            {
                if (!slot.SlotFilled)
                {
                    currentSlot.currentItem = null;
                    currentSlot = slot;
                    currentSlot.currentItem = this;
                }
                break;
            }
        }

        transform.SetParent(currentSlot.transform);
        transform.localPosition = Vector3.zero;
    }
}
