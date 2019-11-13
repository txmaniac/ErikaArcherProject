using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Random;
using System.Collections;
using System.Collections.Generic;

public class PlayerAI : CoreAI{
    
    public Vector3 offset;
    public GameObject[] enemy;
    public void Start(){
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        CoreAIStart();
    }
    
    public void MoveToEnemy(GameObject enemy){
        Transform t = enemy.GetComponent<Transform>();
        if(t==null)
            return;
        else
            AI_move.moveTo(t.position-offset);
    }
    
    public void LookAtEnemy(GameObject enemy){
        AI_move.LookAt(enemy);
    }
    
    // require a update function which listens to the player's input via GUI
    
    
    // Button-centric attacking function
    public AttackEnemy(int index){
        MoveToEnemy(enemy[index]);
    }
}
