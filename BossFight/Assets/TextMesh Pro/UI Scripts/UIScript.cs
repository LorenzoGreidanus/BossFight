using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public GameObject panel;

    public int paused = 0, unpause = 1;
    public bool pause;

    public void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (pause == false)
            {
                PauseMenu();
            } else
            {
                UnPaused();
            }
        }
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Options()
    {
        SceneManager.LoadScene(2);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void back()
    {
        SceneManager.LoadScene(0);
    }

    public void Continue()
    {
        panel.SetActive(false);
    }

    public void PauseMenu()
    {
        panel.SetActive(true);
        Time.timeScale = paused;
        pause = true;
    }

    public void UnPaused()
    {
        panel.SetActive(false);
        Time.timeScale = unpause;
        pause = false;
    }
}
