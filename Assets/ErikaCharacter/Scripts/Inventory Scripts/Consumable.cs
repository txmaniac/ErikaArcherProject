using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "new Consumable", menuName = "Items/Consumable")]
public class Consumable : Item
{
    public int consumableId;
    Consumable()
    {
        id = 0; // for consumable
    }
}
