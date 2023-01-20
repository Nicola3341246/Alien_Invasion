using System.Collections;
using System.Diagnostics;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Transform selfTransform;
    [SerializeField] Rigidbody2D self;
    [SerializeField] Animator playerAnimator;
    Vector2 directions;     

    [SerializeField] Transform playerSword;
    [SerializeField] Vector2 attackRange;
    [SerializeField] LayerMask attackableLayer;
    [SerializeField] float damage;

    [SerializeField] SpriteRenderer mySword;
    [SerializeField] float attackcooldown;
    Stopwatch cooldown = new Stopwatch();

    private void Start()
    {
        cooldown.Start();
    }

    void Update()
    {
        directions.x = Input.GetAxis("Horizontal");
        directions.y = Input.GetAxis("Vertical");

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }

        FacingDirection();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 move;
        move.x = directions.x * moveSpeed;
        move.y = directions.y * moveSpeed;

        playerAnimator.SetFloat("Speed", move.magnitude);
        self.velocity = move;        
    }

    private void Attack()
    {
        if (cooldown.ElapsedMilliseconds > attackcooldown)
        {
            cooldown.Restart();
            //Attackanimation here

            Collider2D[] hitEnemy = Physics2D.OverlapBoxAll(playerSword.position, attackRange, attackableLayer);
            foreach (Collider2D item in hitEnemy)
            {
                try
                {
                    item.GetComponent<EnemyHealth>().HitEnemy(damage);
                }
                catch (System.Exception) { }
            }
        }
    }

    private void FacingDirection()
    {
        // nothing
        if (directions.y != 0 || directions.x != 0)
        {
            // facing left
            /*if (directions.x < 0)
            {
                playerAnimator.SetFloat("Vertical", -1);
                playerAnimator.SetFloat("Horizontal", 0);
            }
            // facing right
            else if (directions.x > 0)
            {
                playerAnimator.SetFloat("Vertical", 1);
                playerAnimator.SetFloat("Horizontal", 0);
            }
            // facing up
            else if (directions.y > 0)
            {
                playerAnimator.SetFloat("Horizontal", 1);
                playerAnimator.SetFloat("Vertical", 0);
            }
            // facing down
            else if (directions.y < 0)
            {
                playerAnimator.SetFloat("Horizontal", -1);
                playerAnimator.SetFloat("Vertical", 0);
            }*/

            float relativPositionX = directions.x;
            float relativPositionY = directions.y;
            // up
            if (relativPositionY < 0 && (relativPositionX / relativPositionY) > -1 && (relativPositionX / relativPositionY) < 1)
            {
                playerAnimator.SetFloat("Horizontal", 0);
                playerAnimator.SetFloat("Vertical", -1);
            }
            // down
            else if (relativPositionY > 0 && (relativPositionX / relativPositionY) > -1 && (relativPositionX / relativPositionY) < 1)
            {
                playerAnimator.SetFloat("Horizontal", 0);
                playerAnimator.SetFloat("Vertical", 1);
            }
            // left
            else if (relativPositionX > 0)
            {
                playerAnimator.SetFloat("Horizontal", 1);
                playerAnimator.SetFloat("Vertical", 0);
            }
            // right
            else if (relativPositionX < 0)
            {
                playerAnimator.SetFloat("Horizontal", -1);
                playerAnimator.SetFloat("Vertical", 0);
            }
        }

    }
}
