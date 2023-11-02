//////////////////////
// HOW TO USE:
// 1. Give sprite a Rigidbody2D
//////////////////////


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    Rigidbody2D rb2d;
    public float p_Thrust;

    private void Start() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if(Input.GetKey(KeyCode.W)) {
            var vel = rb2d.velocity;
            float mag = vel.magnitude;
            if(mag < 2) {
                rb2d.AddForce(new Vector2(0,p_Thrust),ForceMode2D.Impulse);
            }
        }
    }
}
