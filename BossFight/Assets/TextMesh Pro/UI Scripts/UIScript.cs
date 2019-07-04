﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public GameObject panel;
    public AudioMixer audioBitch;

    public int paused = 0, unpause = 1;
    public bool pause;
    public bool stillChoosing;

    public void Update()
    {
        if (stillChoosing == false)
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
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
        ButtonSound();
    }

    public void Options()
    {
        SceneManager.LoadScene(2);
        ButtonSound();
    }

    public void SetVolume(float volume)
    {
        Debug.Log(volume);
        audioBitch.SetFloat("VolumeSlider", volume);

    }

    public void Quit()
    {
        Application.Quit();
        ButtonSound();
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
        ButtonSound();
    }

    public void Continue()
    {
        panel.SetActive(false);
        Time.timeScale = unpause;
        Cursor.lockState = CursorLockMode.Locked;
        ButtonSound();
    }

    public void PauseMenu()
    {
        if (panel != null)
        {
            panel.SetActive(true);
        }
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = paused;
        pause = true;
        ButtonSound();
    }

    public void UnPaused()
    {
        if (panel != null)
        {
            panel.SetActive(false);
        }
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = unpause;
        pause = false;
        ButtonSound();
    }
    public void ButtonSound()
    {
        FindObjectOfType<AudioManager>().Play("ButtonSound");
    }
}
