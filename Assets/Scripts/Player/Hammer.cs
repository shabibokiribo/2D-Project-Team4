// Ignore that this is a shield and not a hammer IDC.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hammer : MonoBehaviour {
    public GameObject hammerAsset;
    public GameObject spawnPointObj;
    private bool canUse;
    public Image shieldImage;

    private void Start() {
        canUse = true;
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.E)) {
            if(GameObject.Find("Hammer(Clone)") == null && canUse) {
                switch(GameObject.Find("Player").GetComponent<SpriteRenderer>().flipX) {
                    case(false):
                        canUse = false;
                        SpawnHammer(1f);
                        break;
                    case(true):
                        canUse = false;
                        SpawnHammer(-1f);
                        break;
                }
            }
        }
    }

    private void SpawnHammer(float spawnShift) {
        Vector2 _spawnPoint = new Vector2(spawnPointObj.transform.position.x + spawnShift, spawnPointObj.transform.position.y);
        GameObject hammer = Instantiate(hammerAsset,_spawnPoint,Quaternion.identity) as GameObject;
        hammer.GetComponent<SpriteRenderer>().sortingOrder = 1;
        shieldImage.color = new Color32(96,96,96,255);
        Invoke("ReturnTime",0.75f);
    }

    private void ReturnTime() {
        canUse = true;
        shieldImage.color = new Color32(255,255,255,255);
    }
}
