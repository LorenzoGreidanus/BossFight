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
    public int amoundOfAttacks;
    public bool standing;
    public bool slashAttack;
    public float attackCooldownReset;
    float attackCooldown;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Animator animator = transform.GetComponent<Animator>();
        animator.SetBool("SlashAttack", false);
        animator.SetBool("TurnAttack", false);

        attackCooldown -= Time.deltaTime;
        if (standing)
        {
            if(attackCooldown <= 0)
            {
                attacking = false;
            }
            if (attacking)
            {
                RandomAttack();

            }
            else
            {
                WalkTowards();
                RotateTowards();
            }
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
        Vector3 pos = transform.position;
        if (Physics.Raycast(new Vector3(pos.x, pos.y - 1.2f, pos.z), transform.forward, out ray, attackRange))
        {
            if (ray.transform.tag == "Player")
            {
                attacking = true;
                RandomAttack();
                Animator animator = transform.GetComponent<Animator>();

                animator.SetBool("Walking", false);
            }
            else
            {
                transform.Translate(walkDirection * movementSpeed * Time.deltaTime);
                Animator animator = transform.GetComponent<Animator>();

                animator.SetBool("Walking", true);
            }
        }
        else
        {
            transform.Translate(walkDirection * movementSpeed * Time.deltaTime);
            Animator animator = transform.GetComponent<Animator>();

            animator.SetBool("Walking", true);
        }
    }

    void RandomAttack()
    {
        randomInt = Random.Range(1, amoundOfAttacks);
        if (randomInt == 1)
        {
            slashAttack = true;
        }
        Attack();

    }

    void Attack()
    {
        if(attackCooldown <= 0)
        {
            attackCooldown = attackCooldownReset;
            if (slashAttack)
            {
                SlashAttack();

            }
        }
        
    }

    void TurnAttack()
    {
        Animator animator = transform.GetComponent<Animator>();

        animator.SetBool("TurnAttack", true);
        turnAttacking = false;
    }

    void SlashAttack()
    {
        Animator animator = transform.GetComponent<Animator>();

        animator.SetBool("SlashAttack", true);
    }
}

