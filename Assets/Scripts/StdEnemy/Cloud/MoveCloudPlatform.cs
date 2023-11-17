using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCloudPlatform : MonoBehaviour {
    private Vector2 target;
    private float speed;
    
    private void Start() {
        speed = 2f;
        target = new Vector2(61.75f,-5.2f);
    }

    private void Update() {
        speed = Mathf.Log(speed,10f) * 8f;
        transform.position = Vector2.MoveTowards(transform.position,target,speed * Time.deltaTime);

        Vector2 v2Pos = transform.position;
        if(v2Pos == target) {
            gameObject.GetComponent<MoveCloudPlatform>().enabled = false;
        }
    }
}
