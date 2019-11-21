using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class EnemyAI : CoreAI {
    
    public Gameobject player;
    public SphereCollider collider;
    public float minDistance;
    public float walkingDist;
    
    public void Start(){
        player = Gameobject.FindWithTag("Player");
        
        collider = GetComponent<SphereCollider>();
        collider.isTrigger = true;
        
        CoreAIStart();
        RandomDestination(walkingDist);
        codeComponent = GetComponent<EnemyAI>();
    }
    
    public void Wander(){
        if((AI_transform.position - dest).magnitude < minDistance){
            StartCoroutine(Wait());
        }
        else{
            moveTo();
        }
    }
    
    public void BattleInit(){
        // TODO : Call the BattleScene here.
        DontDestroyOnLoad(this.gameObject);
        SceneManager.LoadScene("BattleScene",SceneMode.Additive);
        codeComponent.enabled = false;
    }
    
    public void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            BattleInit();
        }
    }
    
    // this involves random selection of attacks based which are based on CharacterStats attached to every character in the game.
    // randomly choose attacks
    
    public void AIAttack(){
           
    }
    
    // Helper functions for animations
    public void Attack1(){
        AI_anim.SetTrigger("Attack1");
    }
    
    public void Attack2(){
        AI_anim.SetTrigger("Attack2");
    }
    
    public void Hit1(){
        AI_anim.SetTrigger("Hit1");
    }
    
    public void Hit2(){
        AI_anim.SetTrigger("Hit2");
    }
    
    public void Death(){
        AI_anim.SetBool("Death",true);
    }
    
    public void Stop(){
        stop();
        AI_anim.SetFloat("Forward",-1f);
    }
    
    public void Walk(){
        AI_anim.SetFloat("Forward", AI.speed * 0.1f);
    }
    
    public void Run(){
        AI_anim.SetFloat("Forward", AI.speed);
    }
    
    IEnumerator Wait(){
        Stop();
        yield return new WaitForSeconds(5f);
        RandomDestination(walkingDist);
        
    }
}
