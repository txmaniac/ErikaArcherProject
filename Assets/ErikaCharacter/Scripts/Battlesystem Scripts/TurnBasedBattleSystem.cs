using UnityEngine;
using System.Collections;
using System;

public class TurnBasedBattleSystem : MonoBehaviour
{

    public GameObject playerCharacter;
    public GameObject enemyCharacter;
    public PlayerAI player;
    public EnemyAI enemy;
    private Animator playerAnim;
    private Animator enemyAnim;
    public float attackSpeed;
    private static bool attackTurn; // attackTurn == true for player's turn; attackTurn == false for enemy's turn
    public static int AttackButton;
    public ScenePoint playerPosition;
    public ScenePoint enemyPosition;
    public GameManager battleManager;
    
    void Start()
    {
        // FirstTurnAllocator chooses the first Turn based on a biased probability allocator
        attackTurn = FirstTurnAllocator();
        playerCharacter = GameObject.FindGameObjectWithTag("Player");
        enemyCharacter = GameObject.FindGameObjectWithTag("Enemy");
        player = playerCharacter.GetComponent<PlayerAI>();
        enemy = enemyCharacter.GetComponent<EnemyAI>();
        playerAnim = playerCharacter.GetComponent<Animator>();
        enemyAnim = enemyCharacter.GetComponent<Animator>();
        BattleSceneSetup();
    }   
    
    public void BattleSceneSetup(){
        playerCharacter.transform.position = playerPosition.point.position;
        enemyCharacter.transform.position = enemyPosition.point.position;
    }
    
    public void Update()
    {

        // attackTurn is true for player and false for enemy
        if (attackTurn)
        {
            GameMove(playerCharacter, enemyCharacter);
        }
        else
        {
            GameMove(enemyCharacter, playerCharacter);
        }
    }

    // this function should be called for turns but should wait for the input. So basically we should toggle after a button click
    public void GameMove(GameObject attacker, GameObject defender)
    {
        // TODO: A menu system which communicates with this function in order to perform an action
        // This function basically handles the actions performed by both player and AI
        // Modular function which involves a conditional arg between player and AI to toggle and perform actions
        
        if(attacker.gameObject.tag == "Player"){
            if(AttackButton != 0){
                
                CallAttackPlayer();
            }
        }
        
        else{
            CallAttackEnemy();
        }
    }

    public bool FirstTurnAllocator()
    {
        // this function helps determine the probability of giving the first move advantage to a given character
        // can be based on certain other parameters which have to be decided based on the GetComponent<CharacterStats>
        // the return type is boolean. Where true is player's turn and false is enemy's turn
        float probability;
        bool turn = false;
        switch (enemyCharacter.GetComponent<CharacterStats>().characterLevel)
        {
            case 0: // easy level enemies. Doesn't matter who gets the turn. Player always wins if played sensibly.
                probability = UnityEngine.Random.Range(0, 1);
                if (probability <= .5)
                    turn = false;
                else
                    turn = true;
                break;

            case 1: // easy medium enemies. Gives a 60 : 40 ratio of probability and yet combat is inclined towards the Player more.
                probability = UnityEngine.Random.Range(0, 1);
                if (probability <= .4)
                    turn = false;
                else
                    turn = true;
                break;

            case 2: // medium enemies. Gives a 70 : 30 ratio of probability and combat gets difficult more inclined that player gets a good start
                probability = UnityEngine.Random.Range(0, 1);
                if (probability <= .3)
                    turn = false;
                else
                    turn = true;
                break;

            case 3: // hard enemies. Gives a 80 : 20 ratio of probability and combat gets difficult more inclined that player gets a good start
                probability = UnityEngine.Random.Range(0, 1);
                if (probability <= .2)
                    turn = false;
                else
                    turn = true;
                break;

            case 4: // expert enemies. Gives a 90 : 10 ratio of probability and combat gets difficult most inclined that player gets a good start
                probability = UnityEngine.Random.Range(0, 1);
                if (probability <= .1)
                    turn = false;
                else
                    turn = true;
                break;
        }

        return turn;
    }
    
    // --------------- BUTTON FUNCTIONS -----------------
    
    public void GUIAttack1(){
        // Melee
        AttackButton = 1;
    }
    
    public void GUIAttack2(){
        // Sword
        AttackButton = 2;
    }
    
    public void GUIAttack3(){
        // Bow and Arrow
        AttackButton = 3;
    }
    
    public void GUIAttack4(){
        // Mystic 1
        AttackButton = 4;
    }
    
    public void GUIAttack5(){
        // Mystic 2
        AttackButton = 5;
    }
    
    public void GUIAttack6(){
        // Mystic 3
        AttackButton = 6;
    }
    
    public void ResetAttackButton(){
        AttackButton = 0;
    }
    
    // --------- ATTACK FUNCTIONS -------------------
    
    public void CallAttackPlayer()
    {

        float offset;
        switch (AttackButton)
        {
            // 1, 2, 3 are mixture of melee and weapon attacks.
            // 4, 5,6 are mixture of some magical attacks.
            case 1: // run attack script which we configured individually.
                    // Kick combo
                offset = 10f;
                // animate before registering an attack
                playerAnim.Play("Attack1");
                break;

            case 2: // run attack script which we configured individually. Sword attack for now
                offset = 8f;
                // animate before registering an attack
                playerAnim.Play("Attack2");
                break;

            case 3: // run attack script which we configured individually. Bow and Arrow for now
                offset = 7f;
                // animate before registering an attack
                playerAnim.Play("Attack3");
                break;

            case 4: // run attack script which we configured individually. Mystic 1 for now
                offset = 4f;
                // animate before registering an attack
                playerAnim.Play("Attack4");
                break;

            case 5: // run attack script which we configured individually. Mystic 2 for now
                offset = 3f;
                // animate before registering an attack
                playerAnim.Play("Attack5");
                break;

            case 6: // run attack script which we configured individually. Mystic 3 for now
                offset = 2f;
                // animate before registering an attack
                playerAnim.Play("Attack6");
                break;
        }
        ToggleTurn();
        ResetAttackButton();
    }
    
    public void CallAttackEnemy()
    {

        float offset;
        switch (UnityEngine.Random.Range(1,7))
        {
            // 1, 2, 3 are melee and weapon attacks.
            // 4, 5, 6 are some magical attacks.
            case 1: // Kick combo
                offset = 10f;
                // animate before registering an attack
                playerAnim.Play("Attack1");
                break;

            case 2: 
                offset = 8f;
                // animate before registering an attack
                playerAnim.Play("Attack2");
                break;

            case 3: 
                offset = 7f;
                // animate before registering an attack
                playerAnim.Play("Attack3");
                break;

            case 4:
                offset = 4f;
                // animate before registering an attack
                playerAnim.Play("Attack4");
                break;

            case 5:
                offset = 3f;
                // animate before registering an attack
                playerAnim.Play("Attack5");
                break;

            case 6:
                offset = 2f;
                // animate before registering an attack
                playerAnim.Play("Attack6");
                break;
        }
        ToggleTurn();
        ResetAttackButton();
    }
    
//     public void Attack(float offset)
//     {
//         // perform the attack animation and all the visual changes in game
//         if(attackTurn){
//             case()
//         }
//     }
// -------- HELPER FUNCTIONS ---------------
    
    public void ToggleTurn(){
        attackTurn = !attackTurn;
    }
    
    IEnumerator WaitForEverything()
    {
        // adds a delay of 2 sec
        yield return new WaitForSeconds(2);
    }
}
