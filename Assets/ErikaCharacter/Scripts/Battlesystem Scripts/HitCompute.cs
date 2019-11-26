using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HitCompute : MonoBehaviour {
    public GameObject player, enemy;
    private CharacterStats enemyStats, playerStats;
    
    public void Start(){
        enemy = GameObject.FindWithTag("Enemy");
        enemyStats = enemy.GetComponent<CharacterStats>();
        playerStats = player.GetComponent<CharacterStats>();
    }
    
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Enemy"){
            if(!enemyStats.dead){
                enemyStats.ApplyDamage(playerStats.damageStrengthSword);
                if(enemyStats.Health <= enemyStats.minHealth){
                    enemyStats.Kill();
                }
            }
        }
        
        // extend the effects of weapon collision
    }
}
