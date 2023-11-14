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

    // Update is called once per frame
    void Update()
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Heart"))
            {
                TakePlayerDamage(1);
            }
        }
   
        
        /*
        if(Input.GetKeyDown(KeyCode.Space)) // TESTING when spacebar is pressed take 1 damage
        {
            TakePlayerDamage(1);
        }
        */
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
