// Ignore that this is a shield and not a hammer IDC.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour {
    public GameObject hammerAsset;
    public GameObject spawnPointObj;
    private float spawnShift = 0f;
    
    private void Update() {
        if(Input.GetKeyDown(KeyCode.E)) {
            switch(GameObject.Find("Player").GetComponent<SpriteRenderer>().flipX) {
                case(false):
                    spawnShift = 1f;
                    break;
                case(true):
                    spawnShift = -1f;
                    break;
            }

            Vector2 _spawnPoint = new Vector2(spawnPointObj.transform.position.x + spawnShift, spawnPointObj.transform.position.y);
            GameObject hammer = Instantiate(hammerAsset,_spawnPoint,Quaternion.identity) as GameObject;
            hammer.GetComponent<SpriteRenderer>().sortingOrder = 1;
        }
    }
}
