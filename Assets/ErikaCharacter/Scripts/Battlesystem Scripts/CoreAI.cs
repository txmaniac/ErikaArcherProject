using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class CoreAI : Monobehaviour {
    public Transform AI_transform;
    public Rigidbody AI_rb;
    public NavMeshAgent AI_nav;
    
    public AIMovement AI_move;
    public AIVision AI_vision;
    public Vector3 dest;
    
    public void CoreAIStart(){
        AI_transform = GetComponent<Transform>();
        AI_rb = GetComponent<Rigidbody>();
        AI_nav = GetComponent<NavMeshAgent>();
        AI_move = new AIMovement(this.gameobject);
        AI_vision = new AIVision(this.gameobject);
    }
    
    public void setDest(Vector3 d){
        dest = d;
    }
    
    public void RandomDestination(){
        NavMeshHit hit;
        Vector3 randomDirection = Random.insideUnitSphere * walkDist;
        randomDirection += my_transform.position;
        NavMesh.SamplePosition(randomDirection, out hit, walkDist, NavMesh.AllAreas);
        setDest(hit.position);
    }
    
    public void moveTo(){
        AI_move.moveTo(dest);
    }
    
    public void moveTo(Gameobject obj){
        AI_move.moveTo(obj);
    }
    
    public void moveTo(Vector3 vec){
        AI_move.moveTo(vec);
    }
    
    public void LookAt(){
        AI_move.LookAt(dest);
    }
    
    public void LookAt(Gameobject obj){
        AI_move.LookAt(obj);
    }
    
    public void LookAt(Vector3 vec){
        AI_move.LookAt(vec);
    }
    
    public void inFieldofView(Gameobject obj){
        AI_vision.inFieldofView(obj);
    }
    
    public void inFieldofView(Vector3 vec){
        AI_vision.inFieldofView(vec);
    }
    
    public void inFieldofView(){
        AI_vision.inFieldofView(dest);
    }
}
