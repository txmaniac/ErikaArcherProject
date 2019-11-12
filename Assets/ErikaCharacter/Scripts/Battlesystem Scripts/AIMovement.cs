using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class AIMovement {
	Transform transform; // transform of the object
	RigidBody rb; // rigidbody of the object
	NavMeshAgent nav; // NavmeshAgent of the object
	
	public AIMovement(Gameobject obj){
		transform = obj.GetComponent<Transform>();
		rb = obj.GetComponent<Rigidbody>();
		nav = obj.GetComponent<NavMeshAgent>();
	}
	
	// Destination of the NPC object set to a certain object
	public void moveTo(GameObject obj)
    {
        Transform t = obj.GetComponent<Transform>();
		
		if(t==null)
			return;
		
		moveTo(t.position);
	}
	
	// Destination of the NPC object set to a certain vector
	public void moveTo(Vector3 vec){
		nav.SetDestination(vec);
	}
	
	// To stop the NPC and keep it standing
	public void stop(){
		nav.ResetPath();
	}
	
	// NPC Looking at a certain object
	public void LookAt(Gameobject obj){
		Transform t = obj.GetComponent<Transform>();
		if(t==null)
			return;
		LookAt(t.position);
	}
	
	// NPC looking at a certain direction
	public void LookAt(Vector3 vec){
		Vector3 lookDirection = pos - transform.position;
        lookDirection.y = 0f;
        Quaternion newRotation = Quaternion.LookRotation(lookDirection);
        rb.MoveRotation(newRotation);
	}
}
