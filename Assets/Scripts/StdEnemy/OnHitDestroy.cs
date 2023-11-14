using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitDestroy : MonoBehaviour {
    void Start() {
        gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        StartCoroutine(TemporaryFadeOut());
    }

    private IEnumerator TemporaryFadeOut() {
        float opacity = 1f;
        while(opacity>0f) {
            opacity -= 0.1f;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,opacity);
            yield return new WaitForSeconds(0.05f);
        }
        Destroy(gameObject);
    }
}
