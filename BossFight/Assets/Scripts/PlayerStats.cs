using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public float health;
    public float startHealth;
    public float stamina;
    public float startStamina;
    public float staminaDebuff;

    public int maxPotions;

    public int attackPower;

    public bool staminaPenalty;
    public int staminaMax;
    [SerializeField]private int staminaRegen;

    public int healthMax;
    public int healPots;
    public float healtGain;

    public Image healthSlider;
    public Image staminaSlider;

    private void Awake()
    {
        staminaPenalty = false;
        health = startHealth;
        stamina = startStamina;
    }
    
    public void Update()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
        if (stamina != staminaMax && gameObject.GetComponent<PlayerMove>().dashCooldown <= 0)
        {
            StaminaRegen();
        }
        if (stamina < 0)
        {
            staminaPenalty = true;
        }
        else if (stamina > staminaDebuff)
        {
            staminaPenalty = false;
        }
        if (health < healthMax)
        {
            Heal();
        }

        healthSlider.fillAmount = health / startHealth;
        staminaSlider.fillAmount = stamina / startStamina;
    }

    public void Damage(float damage)
    {
        health -= damage;
    }

    public void StaminaRegen()
    {
        stamina += staminaRegen * Time.deltaTime;
        if (stamina > staminaMax)
        {
            stamina = staminaMax;
        }
    }

    public void Heal()
    {
        if (Input.GetButtonDown("Interact") && healPots < maxPotions)
        {
            health += 50f;

            healPots++;

            if (health > healthMax)
            {
                health = healthMax;
            }
        }
    }

    public void Knight()
    {
        startHealth = 100f;
        healthMax = 100;

        health = startHealth;

        //attackPower =

        startStamina = 100f;
        staminaMax = 100;
    }

    public void Beserker()
    {
        startHealth = 50f;
        healthMax = 50;

        health = startHealth;

        //attackPower = 

        startStamina = 140f;
        staminaMax = 140;
    }

    public void Paladin()
    {
        startHealth = 200f;
        healthMax = 200;

        health = startHealth;

        //attackPower = 

        startStamina = 50f;
        staminaMax = 50;
    }
}
