//////////////////////
// HOW TO USE:
// 1. Give sprite a Rigidbody2D
// 2. Set mass to a higher number like 3
// 2. (Addendum) If you want heavier movement, make gravity a slightly higher value like 1.2
// 3. Put a 2d square down with a box collider and "is trigger" set to true
// 4. Put another 2d square down as a child to it and give it a box collider with "is trigger" set to false. (this prevents the player from falling through the floor)
// 5. Give the "Platform" tag to the platform with the trigger.
//////////////////////


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    Rigidbody2D rb2d;
    public float p_ThrustVertical;
    public float p_ThrustHorizontal;
    private bool canJump;

    private void Start() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        var vel = rb2d.velocity;
        float mag = vel.magnitude;
        if(Input.GetKeyDown(KeyCode.W)) {
            if(mag < 2 && canJump) {
                rb2d.AddForce(new Vector2(0,p_ThrustVertical),ForceMode2D.Impulse);
            }
        } if(Input.GetKey(KeyCode.A)) {
            if(mag < 2) {
                if(canJump) {
                    rb2d.AddForce(new Vector2(-p_ThrustHorizontal,0),ForceMode2D.Impulse);
                } else {
                    rb2d.AddForce(new Vector2(-p_ThrustHorizontal*3f,0),ForceMode2D.Impulse);
                }
            }
        } if(Input.GetKey(KeyCode.D)) {
            if(mag < 2) {
                if(canJump) {
                    rb2d.AddForce(new Vector2(p_ThrustHorizontal,0),ForceMode2D.Impulse);
                } else {
                    rb2d.AddForce(new Vector2(p_ThrustHorizontal*3f,0),ForceMode2D.Impulse);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Platform") {
            canJump = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col) {
        if(col.gameObject.tag == "Platform") {
            canJump = false;
        }
    }
}
