using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Y : MonoBehaviour {
    Rigidbody2D rb2d;
    public AudioClip[] audios; // 0 jump, 1 land
    AudioSource audioSource;
    public float p_ThrustVertical;
    public bool canJumpY;

    private void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            if(canJumpY) {
                rb2d.AddForce(new Vector2(rb2d.velocity.x*0.5f,p_ThrustVertical),ForceMode2D.Impulse);
                audioSource.PlayOneShot(audios[0],1f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Platform" || col.gameObject.tag == "EnemyPlatform") {
            canJumpY = true;
            audioSource.PlayOneShot(audios[1],1f);
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
