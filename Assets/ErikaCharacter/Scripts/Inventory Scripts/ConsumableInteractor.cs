using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
  This class identifies the gameobject in 3d space as the consumables which are to be added to the inventory on pickup action
  So every object which is tagged with a Consumable tag must have this script attached to it so that we can call the OnTrigger action upon any player interaction
  TODO: Make a link between the physical object and the inventory item.
*/

public class ConsumableInteractor{
  public int consumableId;
  
  void OnTriggerEnter(Collider other){
    if(other.tag == "Player"){
      // Interaction is done by "E" on the keyboard with the gameobject
      if(Input.GetKeyDown(KeyCode.E)){
        // make the object child of the player and copy the transform according to the position which is default to the gameObject.
        // also add the object item in the list of the Inventory.
      }
    }
  }
}
