using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
using System;

public class TurnBasedBattleSystem : MonoBehaviour
{

    public GameObject playerCharacter;
    public GameObject enemyCharacter;
    private Rigidbody playerRigidBody;
    private Rigidbody enemyRigidBody;
    public float attackSpeed;
    private NavMeshAgent attackerNPC;
    private bool attackTurn;
    private Animator anim;
    public int a = 1;
    void Start()
    {
        // FirstTurnAllocator chooses the first Turn based on a biased probability allocator
        attackTurn = FirstTurnAllocator();
        playerCharacter = GameObject.FindGameObjectWithTag("Player");
        enemyCharacter = GameObject.FindGameObjectWithTag("Enemy");
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

    public void GameMove(GameObject attacker, GameObject attackee)
    {
        /*Vector3 direction = attackee.transform.position - attacker.transform.position;
        direction = direction.normalized;
        Vector3 offset;
        float stopping_dist = 2f;
        // call attacker NPC to move towards the attackee and when reached a stopping distance of dist, start attacking
        // execute animations based on button clicks if character is player.
        if ((attackee.transform.position - attacker.transform.position).magnitude > stopping_dist)
        {*/
        if (attacker.CompareTag("Player"))
        {
            // movement script for character towards enemy
            /*attackSpeed = attacker.GetComponent<CharacterStats>().movementSpeed;
            offset = direction * stopping_dist;
            attacker.transform.position += (direction * attackSpeed - offset) * Time.deltaTime;
            *///anim.SetFloat("forward", attacker.transform.position.z);
              // button tags are given as abstraction
              // assumption for now is we have three combo attacks and three magical attacks


            // performing the visual part of the attack
            // we can add all the elements which make our attack more visual here
            switch (a)
            {
                case 1:
                    // 1 melee
                    anim.SetTrigger("perform_attack1");
                    break;
                case 2:
                    // sword
                    anim.SetTrigger("perform_attack2");
                    break;
                case 3:
                    // bow and arrow
                    anim.SetTrigger("perform_attack3");
                    break;
                case 4:
                    // mystic attack 1
                    anim.SetTrigger("perform_attack4");
                    break;
                case 5:
                    // mystic attack 2
                    anim.SetTrigger("perform_attack5");
                    break;
                case 6:
                    // mystic attack 3
                    anim.SetTrigger("perform_attack6");
                    break;
            }
            CallAttack(a);
        }
        // performing the attack (the game manager part)
        else
        {
            // movement script for enemy to move near character
            /*attackSpeed = attacker.GetComponent<CharacterStats>().movementSpeed;
            offset = direction * stopping_dist;
            attacker.transform.position += (direction * attackSpeed - offset) * Time.deltaTime;
            *///anim.SetFloat("forward", attacker.transform.position.z);

            // this part needs certain NavMeshAgent attributes which I'm working on currently. Reminder : Complete by 4th OCT 2019
            // performing the attack (the game manager part)
            CallAttack(UnityEngine.Random.Range(1, 6));
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
        character.GetComponent<CharacterStats>().Health -= damageAmount;
    }

    public void Attack(float offset)
    {
        // performing the attack

        // final damage calculates a UnityEngine.UnityEngine.Random range between ( damageStrength , damageStrength + offset )
        // adds a level of uncertainty in the attack. But maintains a threshold so that player doesn't have any disadvantage

        float finalDamage;
        if (attackTurn)
        {
            finalDamage = UnityEngine.Random.Range(playerCharacter.GetComponent<CharacterStats>().damageStrength, playerCharacter.GetComponent<CharacterStats>().damageStrength + UnityEngine.Random.Range(1, offset));
            Damage(enemyCharacter, finalDamage);
        }
        else
        {
            finalDamage = UnityEngine.Random.Range(enemyCharacter.GetComponent<CharacterStats>().damageStrength, enemyCharacter.GetComponent<CharacterStats>().damageStrength + UnityEngine.Random.Range(1, offset));
            Damage(playerCharacter, finalDamage);
        }
    }

    IEnumerator WaitForEverything()
    {
        // adds a delay of 2 sec
        yield return new WaitForSeconds(2);
    }
}
