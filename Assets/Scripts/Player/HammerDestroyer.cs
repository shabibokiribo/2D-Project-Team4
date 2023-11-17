using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerDestroyer : MonoBehaviour {
    private GameObject player;

    private void Start() {
        player = GameObject.Find("Player");
        Invoke("DestroyGameObject",0.25f);
    }

    private void FixedUpdate() {
        switch(player.GetComponent<SpriteRenderer>().flipX) {
            case(false):
                gameObject.transform.position = new Vector2(player.transform.position.x + 1f, player.transform.position.y);
                break;
            case(true):
                gameObject.transform.position = new Vector2(player.transform.position.x - 1f, player.transform.position.y);
                break;
        }
    }

    private void DestroyGameObject() {
        Destroy(gameObject);
    }
}
