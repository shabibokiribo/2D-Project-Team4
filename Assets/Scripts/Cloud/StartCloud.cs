using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCloud : MonoBehaviour {
    public GameObject cloud;
    private void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Player") {
            Vector3 initialPos = new Vector3(col.gameObject.transform.position.x + 20f,1.2f);
            GameObject _Cloud = Instantiate(cloud,initialPos,Quaternion.identity) as GameObject;
            _Cloud.GetComponent<Cloud>().speed = 3f;
            Destroy(gameObject);
        }
    }
}
