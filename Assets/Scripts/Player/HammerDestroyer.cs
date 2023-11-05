using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerDestroyer : MonoBehaviour {
    private void Start() {
        Invoke("DestroyGameObject",0.25f);
    }

    private void DestroyGameObject() {
        Destroy(gameObject);
    }
}
