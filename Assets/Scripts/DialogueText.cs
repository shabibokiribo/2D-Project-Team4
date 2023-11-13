using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueText : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text txtDialogueRose;
    public TMP_Text txtDialogueCupidTrig;
    float dialogueType = .09f;
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Rose")
        {
            StartCoroutine(Dialogue("Collect roses to confess to your crush",txtDialogueRose));
        }

        if (other.gameObject.tag == "CupidTrig")
        {
            StopAllCoroutines();
            StartCoroutine(Dialogue("Avoid cupid's arrows to stay faithful to your crush", txtDialogueCupidTrig));
        }

    }
    public IEnumerator Dialogue(string text, TMP_Text message)
    {
        message.text = "";
        

        foreach (char c in text)
        {
            message.text += c;
            yield return new WaitForSeconds(dialogueType);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
