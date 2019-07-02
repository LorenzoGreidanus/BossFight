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
            }
            else
            {
                UnPaused();
            }
        }
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
        FindObjectOfType<AudioManager>().Play("ButtonSound");
    }

    public void Options()
    {
        SceneManager.LoadScene(2);
        FindObjectOfType<AudioManager>().Play("ButtonSound");
    }

    public void Quit()
    {
        Application.Quit();
        FindObjectOfType<AudioManager>().Play("ButtonSound");
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<AudioManager>().Play("ButtonSound");
    }

    public void Continue()
    {
        panel.SetActive(false);
        FindObjectOfType<AudioManager>().Play("ButtonSound");
    }

    public void PauseMenu()
    {
        if (panel != null)
        {
            panel.SetActive(true);
        }
        Time.timeScale = paused;
        pause = true;
        FindObjectOfType<AudioManager>().Play("ButtonSound");
    }

    public void UnPaused()
    {
        if (panel != null)
        {
            panel.SetActive(false);
        }
        Time.timeScale = unpause;
        pause = false;
        FindObjectOfType<AudioManager>().Play("ButtonSound");
    }
}
