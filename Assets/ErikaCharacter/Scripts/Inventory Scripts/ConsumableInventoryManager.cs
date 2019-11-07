using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableInventoryManager : MonoBehaviour
{
    public GameObject player;
    public GameObject inventoryPanel;
    public static ConsumableInventoryManager instance;
    public List<Consumable> list = new List<Consumable>();

    public void UpdateSlots()
    {
        int index = 0;
        foreach (Transform child in inventoryPanel.transform)
        {
            InventorySlotController slot = child.GetComponent<InventorySlotController>();

            if (index < list.Count)
            {
                slot.consumable = list[index];
            }

            else
            {
                slot.consumable = null;
            }

            slot.UpdateInfo();
            index++;
        }
    }

    public void Add(Consumable consumable)
    {
        if (list.Count < 35)
        {
            list.Add(consumable);
        }
        UpdateSlots();
    }

    public void Remove(Consumable consumable)
    {
        list.Remove(consumable);
        UpdateSlots();
    }

    private void Start()
    {
        instance = this;
        UpdateSlots();
    }

    public void InventoryMenu()
    {

    }
}
