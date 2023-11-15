using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    
    AudioSource endSFXSource;
    public AudioClip winSFX;
    public AudioClip loseSFX;
    string endGame;

    public Handler handler;
    // Start is called before the first frame update
    void Start()
    {
        endSFXSource=GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Fletcher")
        {
            if (handler.roses == handler.maxRoses)
            {
                endSFXSource.clip = winSFX;
                endGame = "WIN";

            }
            else
            {
                endSFXSource.clip = loseSFX;
                endGame = "LOSE";
            }
            endSFXSource.Play();
            Invoke("LoadEndGame",1.0f);
        }
    }


    void LoadEndGame()
    {
        SceneManager.LoadScene(endGame);
    }

        // Update is called once per frame
    void Update()
    {
       if (handler.currentHealth <= 0)
       { 
             SceneManager.LoadScene("LOSE");
       }
    }
}
