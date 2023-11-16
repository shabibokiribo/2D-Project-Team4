using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class X : MonoBehaviour {
    Rigidbody2D rb2d;
    public float p_ThrustHorizontal;
    private bool wasLastFrameLeft;
    private float lastFrameInput;
    
    private void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        lastFrameInput = 0f;
    }

    /// <summary>
    /// Method <c>FixedUpdate</c> is used to control movement and handle logic when the player stays facing left.
    /// </summary>

    private void FixedUpdate() {
        float h = Input.GetAxis("Horizontal");
        float _hThrust = h * p_ThrustHorizontal;
        if(gameObject.GetComponent<Y>().canJumpY) {
            rb2d.velocity = new Vector2(_hThrust,rb2d.velocity.y);
        } else {
           rb2d.velocity = new Vector2(_hThrust*0.9f,rb2d.velocity.y);
        } 

        if(Mathf.Sign(lastFrameInput) == -1) {
            wasLastFrameLeft = true;
        } else if(wasLastFrameLeft && lastFrameInput == h) {
            wasLastFrameLeft = true;
        } else {
            wasLastFrameLeft = false;
        }

        if(h < 0 || wasLastFrameLeft) {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        } else {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        } 

        lastFrameInput = h; 
    }
}
