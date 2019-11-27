using UnityEngine;

public class PlayerAI : CoreAI{
    
    public Vector3 offset;
    public GameObject enemy, player;
    private CharacterStats playerStats, enemyStats;
    private Animator playerAnim;
    public ScenePoint playerPos;
    
    public void Start(){
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        playerStats = player.GetComponent<CharacterStats>();
        enemyStats = enemy.GetComponent<CharacterStats>();
        CoreAIStart();
    }
    
    //----------------MOVEMENT FUNCTIONS-----------------------
    // move towards the enemy
    public void MoveToEnemy(GameObject enemy){
        Transform t = enemy.GetComponent<Transform>();
        if(t==null)
            return;
        else
            AI_move.moveTo(t.position-offset);
    }
    
    // move away from enemy
    public void MoveAwayfromEnemy(){
        AI_move.moveTo(playerPos.point.position);
    }
    
    // look at the enemy
    public void LookAtEnemy(GameObject enemy){
        AI_move.LookAt(enemy.transform.position);
    }
    
    //---------------ATTACK FUNCTIONS-------------------------
    public void Melee(){
        // perform a melee attack
        playerAnim.Play("Melee");
    }
    
    public void SwordHit(){
        // perform a sword hit
        playerAnim.Play("SwordHit");
    }
    
    public void BowArrow(){
        // perform bow and arrow attack
        // could have a difference in this function since this involves a projectile in action
        playerAnim.Play("BowArrow");
    }
}
