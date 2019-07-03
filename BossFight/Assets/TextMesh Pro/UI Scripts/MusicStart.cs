using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicStart : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("BackGround");
    }
}
