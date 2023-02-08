using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public GameObject PauseUI;
    public GameObject InventoryUI;

    private int escPressed;
    private int iPressed;
    public static Game instance;

    private void Awake()
    {
           instance = this;
        Time.timeScale = 1;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            escPressed++;
            if(escPressed % 2 == 1)
            {
                Pause();
            }
            else if (escPressed % 2 == 0)
            {
                Resume();
            }
        }

        if(Input.GetKeyDown(KeyCode.I))
        {
            iPressed++;
            if(iPressed % 2 ==1)
            {
                openInventory();
            }
            else if (iPressed % 2 == 0)
            {
                InventoryUI.SetActive(false);
                Time.timeScale = 1;
            }
 
        }
    }
    void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
        Debug.Log("paused");
        PauseUI.SetActive(true);
    }
    void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        Debug.Log("resumed");
        PauseUI.SetActive(false);
    }
    public void openInventory()
    {
        Time.timeScale = 0;
        InventoryUI.SetActive(true);
    }
    void OnButtonPause()
    {
        escPressed++;
        Pause();
    }
    void OnButtonResume()
    {
        escPressed++;
        Debug.Log("resume pressed");
        Resume();
    }
    void OnButtonMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
