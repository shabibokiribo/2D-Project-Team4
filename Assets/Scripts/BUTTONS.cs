using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BUTTONS : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickStart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OnClickBack()
    {
        SceneManager.LoadScene("MENU");
    }

    public void OnClickHelp()
    {
        SceneManager.LoadScene("HELP");
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}
