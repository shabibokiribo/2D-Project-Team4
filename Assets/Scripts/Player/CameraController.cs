using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject player;
    public float distanceFromPlayerZ;
    public float distanceFromPlayerY;
    public float speed;

    private Vector3 target;
    private float distance;
    

    private void Start() {
        target = new Vector3(player.transform.position.x, player.transform.position.y, distanceFromPlayerZ);
        distance = Vector3.Distance(gameObject.transform.position,target);
    }

    private void LateUpdate() {
        distance = Vector3.Distance(gameObject.transform.position,target);
        float distanceSpeed = (distance * speed) * 1.2f;
        Debug.Log(distanceSpeed);
        float newDistanceY = (distanceFromPlayerY + player.transform.position.y);
        target = new Vector3(player.transform.position.x, newDistanceY, distanceFromPlayerZ);
        transform.position = Vector3.MoveTowards(transform.position, target, distanceSpeed * Time.deltaTime);
    }
}
