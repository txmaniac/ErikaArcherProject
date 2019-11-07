using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyNPC : MonoBehaviour
{
	public Transform player;
	public float MaxVicinity;
	public float MaxAngle;
	public int _NumberofPoints;
	public Vector3[] points;
	private float vicinity;
	private static int destIndex;
	private Animator enemyAnim;
	private NavMeshAgent enemyAgent;
	
	void Start(){
		enemyAnim = GetComponent<Animator>();
		enemyAgent = GetComponent<NavMeshAgent>();
        enemyAgent.destination = points[0];
		destIndex = Random.Range(0, points.Length-1);
		points = PointAllocator(50, _NumberofPoints);
	}
	
	void Update(){
		// vicinity is the distance between player and enemy
		vicinity = Vector3.Distance(player.transform.position, this.transform.position);
		
		// direction vector towards the player
		Vector3 direction = player.transform.position - this.transform.position;
		direction = direction.normalized;
		
		// angle is the angle between the direction vector and the enemy's forward direction
		float angle;
		angle = Vector3.Angle(direction, this.transform.forward);
		
		if(vicinity < MaxVicinity && angle < MaxAngle){
			Chase();
		}
		
		else{
			Wander();
		}
	}
	
	public void Wander(){
        if (points[destIndex] == transform.position)
        {
            destIndex = (destIndex + 1) % points.Length;
  
            // wait at the destination for sometime and start walking for the next destination
            /*enemyAnim.SetBool("idle", true);
            StartCoroutine(Wait(3));
            enemyAnim.SetBool("idle", false);
*/
            enemyAnim.SetBool("walk", true); // for the time being
        }
        enemyAgent.destination = points[destIndex];
    }

    public void Chase(){
		enemyAgent.destination = player.transform.position;

        if (Vector3.Distance(player.transform.position, this.transform.position) <= enemyAgent.stoppingDistance)
        {
            enemyAnim.SetBool("walk", false);
            enemyAnim.SetBool("attack", true);
        }

        else {
            enemyAnim.SetBool("attack", false);
            enemyAnim.SetBool("walk", true);
        }
	}
	
	public Vector3[] PointAllocator(float radius, int number){
		Vector3[] points = new Vector3[number];
		
		for(int i=0; i < number; i++){
            points[i] = (Random.insideUnitSphere * radius) + transform.position;
		}
		
		return points;
	}
	
	IEnumerator Wait(int num){
		yield return new WaitForSeconds(num);
	}
}