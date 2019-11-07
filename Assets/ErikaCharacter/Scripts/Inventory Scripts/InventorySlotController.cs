using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlotController : MonoBehaviour
{
    public Consumable item;

    public void Use()
    {
        if (item != null && item.id == 0)
        {
            if (item.consumableId == 1) {
                // coke potion
                // give special powers
            }

            if (item.consumableId == 2) {
                // increase health by x hp
            }

            if (item.consumableId == 3) {
                // magic potion
            }

            if(item.consumableId == 4)
            {
                // increase shield by x sp
            }
        }
    }
}
