using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public void OnButtonStart()
    {
        SceneManager.LoadScene(1);
    }
    public void OnButtonQuit()
    {
        Application.Quit();
    }

}
