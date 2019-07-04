using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public BossHealth bossHealth;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Boss"))
        {
            bossHealth.TakeDamage(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().attackPower);
        }
    }
}
