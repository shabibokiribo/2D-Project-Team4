using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {
    private GameObject playerObj;
    public GameObject projectile;
    private Vector2 target;
    private float _distance;
    public float speed;
    public int intTilCloudDeath;
    private Color original = new Color(195f,179f,155f);
    private Color dying = new Color(147f,52f,74f);

    private void Start() {
        intTilCloudDeath = 3;
        playerObj = GameObject.Find("Player"); // PLEASE dont forget this
        target = new Vector2(playerObj.transform.position.x, gameObject.transform.position.y);
        _distance = Vector2.Distance(transform.position,target);
        StartCoroutine(MakeSpeedNormalAfter(3f));
        InvokeRepeating("SpawnHeartProjectile",1f,3f);
    }

    private void FixedUpdate() {
        switch(intTilCloudDeath) {
            case(0):
                Destroy(gameObject);
                break;
        }
    }

    private void LateUpdate() {
        _distance = Vector2.Distance(transform.position,target);
        float distanceSpeed = (_distance * speed) * 1.2f;
        target = new Vector2(playerObj.transform.position.x, gameObject.transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, target, distanceSpeed * Time.deltaTime);
    }

    private void SpawnHeartProjectile() {
        Instantiate(projectile,gameObject.transform.position,Quaternion.identity);
    }

    private IEnumerator MakeSpeedNormalAfter(float time) {
        yield return new WaitForSeconds(time);
        speed = 1.5f;
        yield return null;
    }
}
