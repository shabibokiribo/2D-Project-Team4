//////////////////////
// HOW TO USE:
// 1. Add to the EnemyStd script.
// 2. Change the thrust to something like 300.
//////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowProjectile : MonoBehaviour {
    Rigidbody2D rb2d;
    public float r_thrust; // Thrust of projectile; should be fairly high since it's only run once.
    public bool _Left; // Which direction the projectile travels
    

    private void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        switch(_Left) {
            case(true):
                rb2d.AddForce(Vector2.left * r_thrust);
                break;
            case(false):
                rb2d.AddForce(Vector2.right * r_thrust);
                break;
        }
    }

    private void FixedUpdate() { // Finds the angle that the projectile is traveling.
        var _vel = rb2d.velocity;
        float speed = _vel.magnitude;
        float angle = Mathf.Atan2(_vel.y,_vel.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Player" || col.gameObject.tag == "Platform" || col.gameObject.tag == "Hammer") {
            Destroy(gameObject);
        }
    }
}
