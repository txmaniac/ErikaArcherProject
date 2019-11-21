using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Random;
using System.Collections;
using System.Collections.Generic;

public class PlayerAI : CoreAI{
    
    public Vector3 offset;
    public GameObject enemy;
    public void Start(){
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        CoreAIStart();
    }
    
    // move towards the enemy
    public void MoveToEnemy(GameObject enemy){
        Transform t = enemy.GetComponent<Transform>();
        if(t==null)
            return;
        else
            AI_move.moveTo(t.position-offset);
    }
    
    // look at the enemy
    public void LookAtEnemy(GameObject enemy){
        AI_move.LookAt(enemy);
    }
    
    // attack functions
    
    public void Melee(){
    
    }
    
    public void SwordHit(){
    
    }
    
    public void BowArrow(){
    
    }
    
    
}
