using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartProjectile : MonoBehaviour {
    private float rotation;

    private void Start() {
        rotation = 0f;
        InvokeRepeating("Rotator",0f,1f/120f);
    }
    
    // This is an annoying function to adjust.
    // Basically its a piecewise log function that has a relatively minor curve for the first 10 passes.
    private void Rotator() {
        rotation += 100f;
        float _rotation;
        if(rotation <= 1000f) {
            _rotation = Mathf.Log(rotation,0.05f) * 10;
        } else {
            _rotation = Mathf.Log(rotation,0.5f) * 20;
        }
        transform.rotation = Quaternion.AngleAxis(_rotation, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D col) {
        switch(col.gameObject.tag) {
            case("Platform"):
                Destroy(gameObject);
                break;
            case("Player"):
                Destroy(gameObject);
                break;
            // and so on...
        }
    }
}
