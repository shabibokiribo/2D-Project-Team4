using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStd : MonoBehaviour {
    Rigidbody2D rb2d; // Rigidbody for the object
    public float speed; // Speed modifier
    public bool isLeft; // Changes whether the object is moving left or right
    public GameObject spawningObj; // Where the projectile spawns
    public GameObject projectile; // Projectile prefab
    public AudioClip hit;
    AudioSource audioSource;

    private void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("SpawnProjectile",1.0f,1.0f);
    }

    private void Update() {
        switch(isLeft) {
            case(true):
                rb2d.velocity = new Vector2(-2f,rb2d.velocity.y);
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                break;
            case(false):
                rb2d.velocity = new Vector2(2f,rb2d.velocity.y);
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
                break;
        }
    }

    private void SpawnProjectile() {
        switch(isLeft) {
            case(true):
                spawningObj.transform.localPosition = new Vector2(0f,-0f);
                if(projectile != null) {
                    GameObject myProjectileL = GameObject.Instantiate(projectile,spawningObj.transform.position,Quaternion.Euler(0,0,30)) as GameObject;
                    myProjectileL.GetComponent<ArrowProjectile>()._Left = true;
                }
                break;
            case(false):
                spawningObj.transform.localPosition = new Vector2(0f,0f);
                if(projectile != null) {
                    GameObject myProjectileL = GameObject.Instantiate(projectile,spawningObj.transform.position,Quaternion.Euler(0,0,30)) as GameObject;
                    myProjectileL.GetComponent<ArrowProjectile>()._Left = true;
                }
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Edge") {
            switch(isLeft) {
                case(true):
                    isLeft = false;
                    break;
                case(false):
                    isLeft = true;
                    break;
            }
        } if (col.gameObject.tag == "Hammer") {
            audioSource.PlayOneShot(hit,1f);
            rb2d.velocity = Vector2.zero;
            gameObject.GetComponent<EnemyStd>().enabled = false;
            gameObject.GetComponent<OnHitDestroy>().enabled = true;
        }
    }
}
