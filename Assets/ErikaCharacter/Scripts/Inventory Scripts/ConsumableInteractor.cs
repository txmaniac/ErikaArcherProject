using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
  This class identifies the gameobject in 3d space as the consumables which are to be added to the inventory on pickup action
  So every object which is tagged with a Consumable tag must have this script attached to it so that we can call the OnTrigger action upon any player interaction
  TODO: Make a link between the physical object and the inventory item.
*/

public class ConsumableInteractor{
  public Consumable consumable;
  public GameObject PlayerHand;
  
  void OnTriggerEnter(Collider other){
    if(other.tag == "Player"){
      // Interaction is done by "E" on the keyboard with the gameobject
      if(Input.GetKeyDown(KeyCode.E)){
        // make the object child of the player and copy the transform according to the position which is default to the gameObject.
        // also add the object item in the list of the Inventory.
        transform.parent = PlayerHand.transform;
        FindInList(consumable)
      }
      
      else{
        // show a message on the screen regarding the object and the show the message "Press E to Interact"
      }
    }
  }
  
  public void FindInList(Consumable consumable){
    bool findFlag = false;
    int findIndex;
    for(int i=0; i<ConsumableInventoryManager.instance.list.Count; i++){
      // this condition checks if the object already exists in the inventory
      if(consumable.id == ConsumableInventoryManager.instance.list[i].id){
        findFlag = true;
        findIndex = i;
        break;
      }
    }
    
    // increment the counter of the item in the inventory if the item already exists in the inventory
    // else add the item in the inventory
    if(findFlag){
      ConsumableInventoryManager.instance.list[findIndex].count++;
    }
    else{
      ConsumableInventoryManager.instance.Add(consumable);
    }
  }
}
