using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassesSelect : MonoBehaviour
{
    public int paused = 0, Unpaused = 1;
    public GameObject panel;
    public GameObject thisPanel;
    public void Awake()
    {
        Time.timeScale = paused;
        GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIScript>().stillChoosing = true; 
    }

    public void Knight()
    {
        StanderdFunction();
    }

    public void Berserker()
    {
        StanderdFunction();
    }

    public void Paladin()
    {
        StanderdFunction();
    }

    public void StanderdFunction()
    {
        GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIScript>().stillChoosing = false;
        Time.timeScale = Unpaused;
        panel.SetActive(true);
        thisPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
