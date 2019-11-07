using UnityEngine;

// creating abstract class for character stats. Provides abstraction for all the character stats
public class CharacterStats : MonoBehaviour
{
    public float Health;
    public float maxHealth;
    public float minHealth;
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