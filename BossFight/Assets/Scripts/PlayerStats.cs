using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public float health;
    public float stamina;
    public bool staminaPenalty;
    public float staminaDebuff;

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
        if (stamina != 100 && gameObject.GetComponent<PlayerMove>().dashCooldown <= 0)
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
    }
}
