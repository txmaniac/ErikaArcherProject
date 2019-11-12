using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class EnemyAI : CoreAI {
    
    public Gameobject player;
    public float minDistance;
    public float walkingDist;
    
    public void Start(){
        player = Gameobject.FindWithTag("Player");
        CoreAIStart();
        RandomDestination(walkingDist);
    }
    
    public void Update(){
        if(inFieldofView(player)){
            BattleInit();
        }
        
        else{
            Wander();
        }
    }
    
    public void Wander(){
        if((AI_transform.position - dest).magnitude < minDistance){
            RandomDestination(walkingDist);
        }
        else{
            moveTo();
        }
    }
    
    public void BattleInit(){
        // TODO : Call the TurnBasedBattleSystem here.
    }
    
    public void AIAttack(){
        // this involves random selection of attacks based which are based on CharacterStats attached to every character in the game.
    }
}
