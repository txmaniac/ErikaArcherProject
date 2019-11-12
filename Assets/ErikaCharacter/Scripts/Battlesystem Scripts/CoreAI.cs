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
    public Gameobject player;
    
    public void CoreAIStart(){
        AI_transform = GetComponent<Transform>();
        AI_rb = GetComponent<Rigidbody>();
        AI_nav = GetComponent<NavMeshAgent>();
        AI_move = new AIMovement(this.gameobject);
        AI_vision = new AIVision(this.gameobject);
        player = Gameobject.FindWithTag("Player");
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
    
    public bool inFieldofView(Gameobject obj){
        return AI_vision.inFieldofView(obj);
    }
    
    public bool inFieldofView(Vector3 vec){
        return AI_vision.inFieldofView(vec);
    }
    
    public bool inFieldofView(){
        return AI_vision.inFieldofView(dest);
    }
    
    public void stop(){
        AI_move.stop();
    }
    
    public float Distance(){
        return Vector3.Distance(AI_transform.position,player.transform.position);
    }
}
