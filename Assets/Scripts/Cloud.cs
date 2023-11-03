// TODO:
// Add a curve to the speed;
// The speed will decrease as the target gets closer.
// The cloud should also overshoot a bit, which it seems to already do.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {
    public GameObject playerObj;
    private Vector2 target;
    private Vector2 position;
    private float _distance;
    public float speed;

    private void Start() {
        position = Vector2.zero;
        target = new Vector2(playerObj.transform.position.x, gameObject.transform.position.y);
        _distance = Vector2.Distance(transform.position,target);
    }

    private void LateUpdate() {
        _distance = Vector2.Distance(transform.position,target);
        float distanceSpeed = (_distance * speed) * 1.2f;
        target = new Vector2(playerObj.transform.position.x, gameObject.transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, target, distanceSpeed * Time.deltaTime);
    }

}
