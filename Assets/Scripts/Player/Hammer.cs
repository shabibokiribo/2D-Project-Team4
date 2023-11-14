// Ignore that this is a shield and not a hammer IDC.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour {
    public GameObject hammerAsset;
    public GameObject spawnPointObj;
    
    private void Update() {
        if(Input.GetKeyDown(KeyCode.E)) {
            float h = Input.GetAxis("Horizontal");
            float spawnShift = 0f;
            switch(Mathf.Sign(h)) {
                case(1):
                    spawnShift = 1f;
                    break;
                case(-1):
                    spawnShift = -1f;
                    break;
            }
            Vector2 _spawnPoint = new Vector2(spawnPointObj.transform.position.x + spawnShift, spawnPointObj.transform.position.y);
            GameObject hammer = Instantiate(hammerAsset,_spawnPoint,Quaternion.identity) as GameObject;
            hammer.GetComponent<SpriteRenderer>().sortingOrder = 1;
        }
    }
}
