using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSlot : MonoBehaviour
{
    //Reference to the item inside the currently occupied spot
    public ItemDrag currentItem;

    //Check whether the current slot is occupied by another item
    public bool SlotFilled => currentItem;
}
