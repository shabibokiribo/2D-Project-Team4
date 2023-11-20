
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderScript : MonoBehaviour
{

    public Animator transition;
    public Handler handler;
    public EndGame endgame;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Fletcher")
        {
            if (endgame.endGame == "WIN")
            {
                Invoke("LoadLevTwo", 1.0f);
            }
        }
    }

    public void LoadLevTwo()
    {
        StartCoroutine(LoadLevelTwo(3));
    }

    IEnumerator LoadLevelTwo(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("Level2");
    }
}
