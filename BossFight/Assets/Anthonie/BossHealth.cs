using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image healthBar;


    void Start()
    {
        healthBar = GameObject.FindWithTag("BossHealthbar").GetComponent<Image>();
        health = maxHealth;
    }

    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.fillAmount = health / maxHealth;
        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Animator animator = transform.GetComponent<Animator>();

        animator.SetBool("Die", true);
    }

}
