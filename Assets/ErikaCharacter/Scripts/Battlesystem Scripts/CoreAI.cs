using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class CoreAI : MonoBehaviour {
    public Transform AI_transform;
    public Rigidbody AI_rb;
    public NavMeshAgent AI_nav;
    
    public AIMovement AI_move;
    public AIVision AI_vision;
    public Vector3 dest;
    public GameObject player;
    
    public void CoreAIStart(){
        AI_transform = GetComponent<Transform>();
        AI_rb = GetComponent<Rigidbody>();
        AI_nav = GetComponent<NavMeshAgent>();
        AI_move = new AIMovement(this.gameObject);
        AI_vision = new AIVision(this.gameObject);
        player = GameObject.FindWithTag("Player");
    }
    
    public void setDest(Vector3 d){
        dest = d;
    }
    
    public void RandomDestination(float walkDist){
        NavMeshHit hit;
        Vector3 randomDirection = Random.insideUnitSphere * walkDist;
        randomDirection += AI_transform.position;
        NavMesh.SamplePosition(randomDirection, out hit, walkDist, NavMesh.AllAreas);
        setDest(hit.position);
    }
    
    public void moveTo(){
        AI_move.moveTo(dest);
    }
    
    public void moveTo(GameObject obj){
        AI_move.moveTo(obj);
    }
    
    public void moveTo(Vector3 vec){
        AI_move.moveTo(vec);
    }
    
    public void LookAt(){
        AI_move.LookAt(dest);
    }
    
    public void LookAt(GameObject obj){
        AI_move.LookAt(obj);
    }
    
    public void LookAt(Vector3 vec){
        AI_move.LookAt(vec);
    }
    
    public bool inFieldofView(GameObject obj){
        return AI_vision.InFieldofView(obj);
    }
    
    public bool inFieldofView(Vector3 vec){
        return AI_vision.InFieldofView(vec);
    }
    
    public bool inFieldofView(){
        return AI_vision.InFieldofView(dest);
    }
    
    public void stop(){
        AI_move.stop();
    }
    
    public float Distance(){
        return Vector3.Distance(AI_transform.position,player.transform.position);
    }
}
