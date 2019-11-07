using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotController : MonoBehaviour
{
    public Consumable consumable;
    private TextMeshProUGUI displayText;
    private Image displayImage;
    private Button displayButton;
    private void Start()
    {
        UpdateInfo();
    }

    public void UpdateInfo()
    {
        displayText = transform.Find("Text").GetComponent<TextMeshProUGUI>();
        displayButton = transform.GetComponent<Button>();
        displayImage = transform.Find("Image").GetComponent<Image>();
        

        if (consumable)
        {
            displayButton.interactable = true;
            displayText.text = consumable.name;
            displayImage.sprite = consumable.icon;
            displayImage.color = Color.white;
        }

        else
        {
            displayButton.interactable = false;
            displayText.text = string.Empty;
            displayImage.sprite = null;
            displayImage.color = Color.clear;
        }

        Debug.Log(displayText.text);
    }

    public void Use()
    {
        if (consumable)
        {
            consumable.Use();
        }
    }
    
}
