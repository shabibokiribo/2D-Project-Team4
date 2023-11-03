//////////////////////
// HOW TO USE:
// 1. Add to the EnemyStd script.
// 2. Change the thrust to something like 300.
//////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowProjectile : MonoBehaviour {
    Rigidbody rb;
    public float r_thrust; // Thrust of projectile; should be fairly high since it's only run once.
    public bool _Left; // Which direction the projectile travels
    

    private void Start() {
        rb = GetComponent<Rigidbody>();
        switch(_Left) {
            case(true):
                rb.AddForce(Vector3.left * r_thrust);
                break;
            case(false):
                rb.AddForce(Vector3.right * r_thrust);
                break;
        }
        
        
    }

    private void FixedUpdate() { // Finds the angle that the projectile is traveling.
        var _vel = rb.velocity;
        float speed = _vel.magnitude;
        float angle = Mathf.Atan2(_vel.y,_vel.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward); // 90 may need to be changed if the projectile euler is changed.
    }


}
