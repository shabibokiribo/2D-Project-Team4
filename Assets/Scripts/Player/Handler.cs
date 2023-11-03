using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handler : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D col) {
        switch(col.gameObject.tag) {
            case("Rose"):
                //value++
                Destroy(col.gameObject);
                break;
        }
    }
}
