using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class X : MonoBehaviour {
    Rigidbody2D rb2d;
    public float p_ThrustHorizontal;

    private void Start() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        float h = Input.GetAxis("Horizontal");
        h *= p_ThrustHorizontal;
        if(gameObject.GetComponent<Y>().canJumpY) {
            rb2d.velocity = new Vector2(h,rb2d.velocity.y);
        } else {
           rb2d.velocity = new Vector2(h*0.9f,rb2d.velocity.y);
        }
    }
}
