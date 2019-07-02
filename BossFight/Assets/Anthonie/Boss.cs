using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    GameObject player;
    public float movementSpeed;
    public RaycastHit ray;
    public float attackRange;
    public float turnTimeReset;
    float turnTime;
    public float rotateSpeed;
    bool attacking;
    int randomInt;
    bool turnAttacking;
    public Vector3 walkDirection;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Attack();
        if (!attacking)
        {
            RotateTowards();
            WalkTowards();
        }

    }

    void RotateTowards()
    {
        Vector3 direction = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z) - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
    }

    void WalkTowards()
    {
        if (Physics.Raycast(transform.position, transform.forward, out ray, attackRange))
        {
            if (ray.transform.tag == "Player")
            {
                attacking = true;
                RandomAttack();
            }
            else
            {
                transform.Translate(walkDirection * movementSpeed * Time.deltaTime);
            }
        }
        else
        {
            transform.Translate(walkDirection * movementSpeed * Time.deltaTime);
        }
    }

    void RandomAttack()
    {
        randomInt = Random.Range(1, 1);
        if (randomInt == 1)
        {
            turnTime = turnTimeReset;

            turnAttacking = true;
        }
        attacking = true;

    }

    void Attack()
    {
        if (turnAttacking)
        {
            turnTime -= Time.deltaTime;
            if (turnTime < 0)
            {
                turnAttacking = false;
                attacking = false;
            }
            TurnAttack();

        }
    }

    void TurnAttack()
    {
        transform.Rotate(new Vector3(0, 1, 0) * rotateSpeed * Time.deltaTime);
    }
}

