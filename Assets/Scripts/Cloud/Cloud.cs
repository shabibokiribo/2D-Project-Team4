using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {
    public GameObject playerObj;
    public GameObject projectile;
    private Vector2 target;
    private Vector2 position;
    private float _distance;
    public float speed;

    private void Start() {
        position = Vector2.zero;
        target = new Vector2(playerObj.transform.position.x, gameObject.transform.position.y);
        _distance = Vector2.Distance(transform.position,target);
        InvokeRepeating("SpawnHeartProjectile",1f,3f);
    }

    private void LateUpdate() {
        _distance = Vector2.Distance(transform.position,target);
        float distanceSpeed = (_distance * speed) * 1.2f;
        target = new Vector2(playerObj.transform.position.x, gameObject.transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, target, distanceSpeed * Time.deltaTime);
    }

    private void SpawnHeartProjectile() {
        Instantiate(projectile,gameObject.transform.position,Quaternion.Euler(0,0,0));
    }
}
