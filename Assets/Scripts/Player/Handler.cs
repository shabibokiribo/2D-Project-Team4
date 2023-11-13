using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handler : MonoBehaviour {
    public Sprite[] sprites; // 0 idle, 1 run, 2 jump
    
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
                //value++
                Destroy(col.gameObject);
                break;
            case("Enemy"):
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,0f);
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,0f);
                gameObject.GetComponent<X>().enabled = false;
                gameObject.GetComponent<Y>().enabled = false;
                StartCoroutine(temporaryAnimation());
                break;
            case("Arrow"):
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,0f);
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,0f);
                gameObject.GetComponent<X>().enabled = false;
                gameObject.GetComponent<Y>().enabled = false;
                StartCoroutine(temporaryAnimation());
                break;
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
