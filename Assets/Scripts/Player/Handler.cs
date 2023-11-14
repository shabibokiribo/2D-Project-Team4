using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Handler : MonoBehaviour {
    public Sprite[] sprites; // 0 idle, 1 run, 2 jump
    //private int lives;

    public int maxHealth = 5; //should do the same thing as lives
    public int currentHealth;

    public HealthBar healthBar;

    

    private void Start() {
        //lives = 3;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    
    private void Update() {
        switch(maxHealth) {
            case(0):
                Debug.Log("YOU LOSE!!!!");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break;
        }
    }
    
    // Sprite updator
    private void FixedUpdate() {
        float x = gameObject.GetComponent<Rigidbody2D>().velocity.x;
        float y = gameObject.GetComponent<Rigidbody2D>().velocity.y;

        if(x != 0) {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
        } if(x == 0 && y == 0) {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
        } if(y != 0) {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[2];
        }
    }



    private void OnTriggerEnter2D(Collider2D col) {
        switch(col.gameObject.tag) {
            case("Rose"):
                //GainHealth(1);


                Destroy(col.gameObject);
                break;
            case("Enemy"):
                TakePlayerDamage(1); //decrease Healthbar by 1


                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,0f);
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,0f);
                gameObject.GetComponent<X>().enabled = false;
                gameObject.GetComponent<Y>().enabled = false;
                StartCoroutine(temporaryAnimation());
                break;
            case("Arrow"):
                TakePlayerDamage(1); //decrease Healthbar by 1

                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,0f);
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,0f);
                gameObject.GetComponent<X>().enabled = false;
                gameObject.GetComponent<Y>().enabled = false;
                StartCoroutine(temporaryAnimation());
                break;
            case("Heart"):
                TakePlayerDamage(1); //decrease Healthbar by 1
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,0f);
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,0f);
                gameObject.GetComponent<X>().enabled = false;
                gameObject.GetComponent<Y>().enabled = false;
                StartCoroutine(temporaryAnimation());
                break;
            case("DeathZone"):
                Debug.Log("YEOWCH!");
                StartCoroutine(temporaryAnimation());
                gameObject.transform.position = new Vector3(-6.5f,-3.2f,0f);
                break;
        }
    }


    void TakePlayerDamage(int damage) // decrease player's health by a number
    {
        if (currentHealth <= 5 && currentHealth >= 0) //Player's health must be between 0 and 5 to take damage
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
        }
    }

    void GainHealth (int hp) // decrease player's health by a number
    {
        if (currentHealth <= 5 && currentHealth >= 0) //Player's health must be between 0 and 5 to gain health
        {
            currentHealth = hp;
            healthBar.SetHealth(currentHealth);
        }
    }


    // Temporary animation until someone gets around to making a real one.
    private IEnumerator temporaryAnimation() {
        for(int i=5;i>0;i--) {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(0.1f);
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
        gameObject.GetComponent<X>().enabled = true;
        gameObject.GetComponent<Y>().enabled = true;
        yield return null;
    }
}
