using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public float health;
    public float stamina;
    public float staminaDebuff;

    public int attackPower;

    public bool staminaPenalty;
    public int staminaMax;

    public int healthMax;
    public int healPots;
    public float healtGain;

    public Image healthSlider;
    public Image staminaSlider;

    private void Awake()
    {
        staminaPenalty = false;
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

        healthSlider.fillAmount = health / 100f;
        staminaSlider.fillAmount = stamina / 100f;
    }

    public void Damage(float damage)
    {
        health -= damage;
    }

    public void StaminaRegen()
    {
        stamina += 10 * Time.deltaTime;
        if (stamina > staminaMax)
        {
            stamina = staminaMax;
        }
    }

    public void Heal()
    {
        if (Input.GetButtonDown("Interact") && healPots < 3)
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
        health = 100f;
        healthMax = 100;

        //attackPower =

        stamina = 100f;
        staminaMax = 100;
    }

    public void Beserker()
    {
        health = 50f;
        healthMax = 50;

        //attackPower = 

        stamina = 140f;
        staminaMax = 140;
    }

    public void Paladin()
    {
        health = 200f;
        healthMax = 200;

        //attackPower = 

        stamina = 50f;
        staminaMax = 50;
    }
}
