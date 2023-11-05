using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject player;
    public bool isScrolling;
    private bool canStart;
    public float distanceFromPlayerZ;
    public float distanceFromPlayerY;
    public float speed;

    private Vector3 target;
    private float distance;
    

    private void Start() {
        switch(isScrolling) {
            case(true):
                canStart = false;
                Invoke("StartScrollingAfter",1f);
                break;
            case(false):
                target = new Vector3(player.transform.position.x, player.transform.position.y, distanceFromPlayerZ);
                distance = Vector3.Distance(gameObject.transform.position,target);
                break;
        }
    }

    private void LateUpdate() {
        switch(isScrolling) {
            case(true):
                switch(canStart) {
                    case(true):
                        transform.Translate(Vector2.right * speed * Time.deltaTime);
                        break;
                    case(false):
                        break;
                } break;
            case(false):
                distance = Vector3.Distance(gameObject.transform.position,target);
                float distanceSpeed = (distance * speed) * 1.2f;
                float newDistanceY = (distanceFromPlayerY + player.transform.position.y);
                target = new Vector3(player.transform.position.x, newDistanceY, distanceFromPlayerZ);
                transform.position = Vector3.MoveTowards(transform.position, target, distanceSpeed * Time.deltaTime);
                break;
        }
    }

    private void StartScrollingAfter() {
        canStart = true;
        Debug.Log("Starting");
    }
}
