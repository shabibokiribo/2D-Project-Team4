using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour {
    private Image background;
    private Vector2 lastScreenSize = new Vector2(0f,0f);

    private void Start() {
        background = GetComponent<Image>();
        lastScreenSize.x = Screen.width;
        lastScreenSize.y = Screen.height;
        background.rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
    }

    private void Update() {
        if(lastScreenSize.x!=Screen.width || lastScreenSize.y!=Screen.height) {
            background.rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
        } else {
            lastScreenSize.x = Screen.width;
            lastScreenSize.y = Screen.height;
        }
        
        
    }

}
