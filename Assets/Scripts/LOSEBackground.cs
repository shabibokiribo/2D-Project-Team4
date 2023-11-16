// Genuinely disgusting code but it works.
// Fades between 3 images every 4 seconds.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LOSEBackground : MonoBehaviour {
    public GameObject[] panels = new GameObject[3];
    private int pass;

    private void Start() {
        pass = 0;
        InvokeRepeating("CallBackgrounds",0f,4f);
    }

    private void CallBackgrounds() {
        Invoke("SwitchBackgrounds",4f);
    }

    private void SwitchBackgrounds() {
        switch(pass) {
            case(0):
                StartCoroutine(FadePanel(0,1,false));
                pass++;
                break;
            case(1):
                StartCoroutine(FadePanel(1,2,false));
                pass++;
                break;
            case(2):
                StartCoroutine(FadePanel(2,0,true));
                pass = 0;
                break;
        }
    }

    private IEnumerator FadePanel(int panel1,int panel2,bool isThird) {
        float opacity;
        switch(isThird) {
            case(true):
                panels[panel2].GetComponent<Image>().color = new Color(1f,1f,1f,0f);
                panels[panel2].SetActive(true);
                opacity = 0f;
                while(opacity<=1f) {
                    panels[panel2].GetComponent<Image>().color = new Color(1f,1f,1f,opacity);
                    opacity += 0.01f;
                    yield return new WaitForSeconds(0.01f);
                }
                panels[panel1].SetActive(false);
                //panels[panel2].GetComponent<Image>().color = new Color(1f,1f,1f,0f);
                break;
            case(false):
                panels[panel2].SetActive(true);
                opacity = 1f;
                while(opacity>=0f) {
                    panels[panel1].GetComponent<Image>().color = new Color(1f,1f,1f,opacity);
                    opacity -= 0.01f;
                    yield return new WaitForSeconds(0.01f);
                }
                panels[panel1].SetActive(false);
                panels[panel1].GetComponent<Image>().color = new Color(1f,1f,1f,1f);
                break;
        }
        
        
    }
}
