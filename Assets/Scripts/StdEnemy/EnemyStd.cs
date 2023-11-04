using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStd : MonoBehaviour {
    Rigidbody2D rb2d; // Rigidbody for the object
    public float speed; // Speed modifier
    public bool isLeft; // Changes whether the object is moving left or right
    public GameObject spawningObj; // Where the projectile spawns
    public GameObject projectile; // Projectile prefab

    private void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        InvokeRepeating("SpawnProjectile",1.0f,1.0f);
    }

    private void Update() {
        switch(isLeft) {
            case(true):
                rb2d.velocity = new Vector2(-2f,rb2d.velocity.y);
                break;
            case(false):
                rb2d.velocity = new Vector2(2f,rb2d.velocity.y);
                break;
        }
    }

    private void SpawnProjectile() {
        switch(isLeft) {
            case(true):
                spawningObj.transform.localPosition = new Vector2(-0.4f,0.4f);
                GameObject myProjectileL = GameObject.Instantiate(projectile,spawningObj.transform.position,Quaternion.Euler(0,0,90)) as GameObject;
                myProjectileL.GetComponent<ArrowProjectile>()._Left = true;
                break;
            case(false):
                spawningObj.transform.localPosition = new Vector2(0.4f,0.4f);
                GameObject myProjectileR = GameObject.Instantiate(projectile,spawningObj.transform.position,Quaternion.Euler(0,0,90)) as GameObject;
                myProjectileR.GetComponent<ArrowProjectile>()._Left = false;
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
        }
    }
}
