// Script moves rose up and down based on sine wave.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rose : MonoBehaviour {
    public float scale;
    private float angle = 0;
    private Vector2 original;

    private void Start() {
        original.y = gameObject.transform.position.y;
    }

    private void FixedUpdate() {
        float toRad = 0;
        switch(angle) {
            case(180):
                angle = 0;
                break;
            default:
                angle++;
                toRad = (angle * Mathf.Deg2Rad);
                gameObject.transform.position = new Vector2(gameObject.transform.position.x,original.y + Mathf.Sin(toRad) * scale);
                break;
        }
    }
}
