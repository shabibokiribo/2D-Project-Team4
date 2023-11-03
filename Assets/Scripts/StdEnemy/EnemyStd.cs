//////////////////////
// HOW TO USE:
// 1. Add the script to an enemy gameObject.
// 2. Give the enemy gameObject a rigidbody and sphere collider. 
// 3. Make sure "Use Gravity" is ticked off.
// 4. Put a platform under the enemy gameObject.
// 5. Put two boxes as children to the platform object. 
// 6. Untick the MeshCollider component to these two objects.
// 7. Tick on the "Is Trigger" option under the box collider component for these two objects.
// 8. Give both objects the tag "Edge".
// 9. If you want to change the spawning position of the projectiles, go to this script and edit lines 45 and 50.
// 9. (Addendum) If you want to change the angle the projectile spawns at, edit lines 49 and 54 to the correct angles (Quaternion.Euler(x,y,z)).
// 10. Make sure to set the spawningObj and projectile GameObjects.
// 11. When in doubt, use my template scene called Enemy1Template.
//////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStd : MonoBehaviour {
    Rigidbody2D rb2d; // Rigidbody for the object
    public float speed; // Speed modifier
    public bool isLeft; // Changes whether the object is moving left or right
    public GameObject spawningObj; // Where the projectile spawns
    public GameObject projectile; // Projectile prefab

    private void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        InvokeRepeating("SpawnProjectile",1.0f,1.0f);
    }

    private void Update() {
        switch(isLeft) {
            case(true):
                gameObject.transform.Translate(Vector2.left * Time.deltaTime * speed, Space.World);
                break;
            case(false):
                gameObject.transform.Translate(Vector2.right * Time.deltaTime * speed, Space.World);
                break;
        }
    }

    private void SpawnProjectile() {
        switch(isLeft) {
            case(true):
                spawningObj.transform.localPosition = new Vector2(-0.4f,0.4f);
                GameObject myProjectileL = GameObject.Instantiate(projectile,spawningObj.transform.position,Quaternion.Euler(0,0,90)) as GameObject;
                myProjectileL.GetComponent<ArrowProjectile>()._Left = true;
                break;
            case(false):
                spawningObj.transform.localPosition = new Vector2(0.4f,0.4f);
                GameObject myProjectileR = GameObject.Instantiate(projectile,spawningObj.transform.position,Quaternion.Euler(0,0,270)) as GameObject;
                myProjectileR.GetComponent<ArrowProjectile>()._Left = false;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Edge") {
            switch(isLeft) {
                case(true):
                    isLeft = false;
                    break;
                case(false):
                    isLeft = true;
                    break;
            }
            Debug.Log(isLeft);
        }
    }
}
