using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerDestroyer : MonoBehaviour {
    private GameObject player;

    private void Start() {
        Invoke("DestroyGameObject",0.25f);
        player = GameObject.Find("Player");
    }

    private void FixedUpdate() {
        float h = Input.GetAxis("Horizontal");
        if(h>=0) {
            gameObject.transform.position = new Vector2(player.transform.position.x + 1, player.transform.position.y);
        } else {
            gameObject.transform.position = new Vector2(player.transform.position.x - 1, player.transform.position.y);
        }
       
    }

    private void DestroyGameObject() {
        Destroy(gameObject);
    }
}
