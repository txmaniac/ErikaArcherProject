using UnityEngine;
using UnityEngine.Random;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
using System;

public class TurnBasedBattleSystem : MonoBehaviour
{

    public GameObject playerCharacter;
    public GameObject enemyCharacter;
    public float attackSpeed;
    private bool attackTurn;
    public int a = 1;
    public ScenePoint playerPosition;
    public ScenePoint enemyPosition;
    public GameManager battleManager;
    
    void Start()
    {
        // FirstTurnAllocator chooses the first Turn based on a biased probability allocator
        attackTurn = FirstTurnAllocator();
        playerCharacter = GameObject.FindGameObjectWithTag("Player");
        enemyCharacter = GameObject.FindGameObjectWithTag("Enemy");
        BattleSceneSetup();
    }   
    
    public void BattleSceneSetup(){
        playerCharacter.transform = playerPosition;
        enemyCharacter.transform = enemyPosition;
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

    public void GameMove(GameObject attacker, GameObject defender)
    {
        // TODO: A menu system which communicates with this function in order to perform an action
        // This function basically handles the actions performed by both player and AI
        // Modular function which involves a conditional arg between player and AI to toggle and perform actions
        
        
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
                probability = Random.Range(0, 1);
                if (probability <= .5)
                    turn = false;
                else
                    turn = true;
                break;

            case 1: // easy medium enemies. Gives a 60 : 40 ratio of probability and yet combat is inclined towards the Player more.
                probability = Random.Range(0, 1);
                if (probability <= .4)
                    turn = false;
                else
                    turn = true;
                break;

            case 2: // medium enemies. Gives a 70 : 30 ratio of probability and combat gets difficult more inclined that player gets a good start
                probability = Random.Range(0, 1);
                if (probability <= .3)
                    turn = false;
                else
                    turn = true;
                break;

            case 3: // hard enemies. Gives a 80 : 20 ratio of probability and combat gets difficult more inclined that player gets a good start
                probability = Random.Range(0, 1);
                if (probability <= .2)
                    turn = false;
                else
                    turn = true;
                break;

            case 4: // expert enemies. Gives a 90 : 10 ratio of probability and combat gets difficult most inclined that player gets a good start
                probability = Random.Range(0, 1);
                if (probability <= .1)
                    turn = false;
                else
                    turn = true;
                break;
        }

        return turn;
    }

    public void CallAttack(int AttackButton)
    {

        float offset;
        switch (AttackButton)
        {
            // 1, 2, 3 are mixture of melee and weapon attacks.
            // 4, 5,6 are mixture of some magical attacks.
            case 1: // run attack script which we configured individually.
                    // Kick combo
                offset = 10f;
                Attack(offset);
                break;

            case 2: // run attack script which we configured individually. Sword attack for now
                offset = 8f;
                Attack(offset);
                break;

            case 3: // run attack script which we configured individually. Bow and Arrow for now
                offset = 7f;
                Attack(offset);
                break;

            case 4: // run attack script which we configured individually. Mystic 1 for now
                offset = 4f;
                Attack(offset);
                break;

            case 5: // run attack script which we configured individually. Mystic 2 for now
                offset = 3f;
                Attack(offset);
                break;

            case 6: // run attack script which we configured individually. Mystic 3 for now
                offset = 2f;
                Attack(offset);
                break;
        }
    }

    public void Damage(GameObject character, float damageAmount)
    {
        // GetComponent<CharacterStats> is a class which is present on both enemy and player which basically handles the physical attributes of a character like :
        // health
        // damangeAmount
        // character class of the enemy
        // movement speed

        // reducing the health of the character (can be player/ enemy)
        character.GetComponent<CharacterStats>().ApplyDamage(damageAmount);
    }

    public void Attack(float offset)
    {
        // performing the attack

        // final damage calculates a UnityEngine.UnityEngine.Random range between ( damageStrength , damageStrength + offset )
        // adds a level of uncertainty in the attack. But maintains a threshold so that player doesn't have any disadvantage

        float finalDamage;
        if (attackTurn)
        {
            finalDamage = Random.Range(playerCharacter.GetComponent<CharacterStats>().damageStrength, playerCharacter.GetComponent<CharacterStats>().damageStrength + UnityEngine.Random.Range(1, offset));
            Damage(enemyCharacter, finalDamage);
        }
        else
        {
            finalDamage = Random.Range(enemyCharacter.GetComponent<CharacterStats>().damageStrength, enemyCharacter.GetComponent<CharacterStats>().damageStrength + UnityEngine.Random.Range(1, offset));
            Damage(playerCharacter, finalDamage);
        }
    }

    IEnumerator WaitForEverything()
    {
        // adds a delay of 2 sec
        yield return new WaitForSeconds(2);
    }
}
