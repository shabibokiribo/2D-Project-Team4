using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{

    public int maxHealth = 5; 
    public int currentHealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void TakePlayerDamage(int damage) // decrease player's health by a number
    {
        if (currentHealth <= 5 && currentHealth >= 0) //Player's health must be between 0 and 5 to take damage
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
        }
    }
}
