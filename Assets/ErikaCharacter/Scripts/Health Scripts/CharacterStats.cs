using UnityEngine;

// creating abstract class for character stats. Provides abstraction for all the character stats
public class CharacterStats : MonoBehaviour
{
    public float Health;
    public float Shield;
    public float Magic;
    public float maxHealth;
    public float minHealth;
    public float maxShield;
    public float minShield;
    public float maxMagic;
    public float minMagic;
    public float damageStrength;
    public float movementSpeed;
    public int characterLevel;

    public void ApplyHealth(float health)
    {
        if(Health + health <= maxHealth)
        {
            Health += health;
        }

        else
        {
            Health = maxHealth;
        }
    }

    public void ApplyShield(float shield)
    {
        if (Shield + shield <= maxShield)
        {
            Shield += shield;
        }

        else
        {
            Shield = maxShield;
        }
    }
    public void ApplyMagic(float magic)
    {
        if (Magic + magic <= maxMagic)
        {
            Magic += magic;
        }

        else
        {
            Health = maxHealth;
        }
    }
    public void ApplyDamage()
    {
        if (Health - damageStrength >= minHealth)
        {
            Health -= damageStrength;
        }

        else
        {
            Health = minHealth;
        }
    }
}