using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Y : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float p_ThrustVertical;
    public bool canJumpY;

    private void Start() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            if(canJumpY) {
                rb2d.AddForce(new Vector2(rb2d.velocity.x*0.5f,p_ThrustVertical),ForceMode2D.Impulse);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Platform" || col.gameObject.tag == "EnemyPlatform") {
            canJumpY = true;
        } if(rb2d.velocity.y > 0 && col.gameObject.tag == "EnemyPlatform") {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col) {
        if(col.gameObject.tag == "Platform" || col.gameObject.tag == "EnemyPlatform") {
            canJumpY = false;
        } if(col.gameObject.tag == "EnemyPlatform") {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
}
