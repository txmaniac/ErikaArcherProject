using UnityEngine;
using System.Collections;

public class EnemyNPC_old : MonoBehaviour
{
	public Transform player;
	public float stopping_dist;
	public float max_visible_range;
	public float movementSpeed;
	private Animator enemyAnim;
	
	void Start(){
		enemyAnim = GetComponent<Animator>();
	}
	
	void Update(){
		if((player.transform.position - this.transform.position).magnitude < 10){
			Chase();
		}
	}
	
	// purpose of chase function is to chase the player. Not initiate attack.
	// Call attack when the distance between player and enemy is <= stopping distance
	
	public void Chase(){
		bool attack;
		bool idle;
		bool walk;

		float angle;
		Vector3 direction = player.transform.position - this.transform.position;
		angle = Vector3.Angle(direction, this.transform.forward);
		
		// angle here is angle of visibility
		direction.y = 0;
		this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction),0.1f);
		if(direction.magnitude <= stopping_dist && angle < 30){
			attack = true;
			idle = false;
			walk = false;
				
			// Attack is called
			enemyAnim.SetBool("attack",attack);
			enemyAnim.SetBool("idle",idle);
			enemyAnim.SetBool("walk",walk);
		}
			
		else if(direction.magnitude <= max_visible_range && angle < 30){
			attack = false;
			idle = false;
			walk = true;
			this.transform.Translate(0f,0f,movementSpeed * Time.deltaTime);
				
			// call animator to animate movements of the NPC here
			enemyAnim.SetBool("attack",attack);
			enemyAnim.SetBool("idle",idle);
			enemyAnim.SetBool("walk",walk);
		}
			
		else{
			attack = false;
			idle = true;
			walk = false;
				
			// call idle || wander or search animation
			enemyAnim.SetBool("attack",attack);
			enemyAnim.SetBool("idle",idle);
			enemyAnim.SetBool("walk",walk);
		}
	}
}