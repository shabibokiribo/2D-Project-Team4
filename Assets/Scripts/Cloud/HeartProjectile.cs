using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartProjectile : MonoBehaviour {
    private float rotation;

    private void Start() {
        rotation = 0f;
        InvokeRepeating("Rotator",0f,1f/120f);
    }

    private void Rotator() {
        rotation += 1f;
        rotation += Time.fixedDeltaTime * 0.5f;
        Debug.Log(rotation);
        transform.rotation = Quaternion.AngleAxis(rotation, Vector3.forward);
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
