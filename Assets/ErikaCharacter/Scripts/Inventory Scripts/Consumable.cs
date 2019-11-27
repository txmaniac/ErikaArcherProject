using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "new Consumable", menuName = "Items/Consumable")]
public class Consumable : Item
{
    public float heal = 0f;
    public float magic = 0f;
    public float shield = 0f;
    internal int count;

    Consumable()
    {
        id = 0;
    }

    public override void Use()
    {
        // add these values always and monitor them from the Scriptable objects
        // pretty straightforward addition

        GameObject player = ConsumableInventoryManager.instance.player;
        CharacterStats playerStats = player.GetComponent<CharacterStats>();

        // work of health potion
        playerStats.ApplyHealth(heal);

        // work of magic potion
        playerStats.ApplyMagic(magic);

        // work of shield potion
        playerStats.ApplyShield(shield);
    }
}
