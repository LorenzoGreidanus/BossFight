using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    bool activated;
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "BossTrigger" && !activated)
        {
            activated = true;
            Animator animator = other.transform.GetComponent<Animator>();

            animator.SetBool("Stand", true);
        }
    }
}
