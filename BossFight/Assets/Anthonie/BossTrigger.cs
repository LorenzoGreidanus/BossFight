using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public GameObject boss;
    bool activated;
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "BossTrigger" && !activated)
        {
            activated = true;
            Animator animator = boss.transform.GetComponent<Animator>();

            animator.SetBool("Stand", true);
            boss.GetComponent<Boss>().standing = true;
        }
    }
}
