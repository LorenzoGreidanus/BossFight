using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    public Vector3 velocity;
    public Vector3 position;
    public float damage;
    public float damageMultiplier;


    private void Update()
    {
        velocity = position - transform.position;
        position = transform.position;

        DamageManager();
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            DamageManager();
            collision.transform.GetComponent<PlayerStats>().Damage(damage);
        }
    }

    void DamageManager()
    {
        
        if (velocity.x < 0)
        {
            velocity.x -= velocity.x * 2;
        }
        if (velocity.y < 0)
        {
            velocity.y -= velocity.y * 2;
        }
        if (velocity.z < 0)
        {
            velocity.z -= velocity.z * 2;
        }
        damage = (velocity.x + velocity.y + velocity.z) * damageMultiplier;
    }
}
