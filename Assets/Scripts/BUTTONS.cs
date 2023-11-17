using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BUTTONS : MonoBehaviour
{
    public void OnClickStart()
    {
        SceneManager.LoadScene("LEVEL1");
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
