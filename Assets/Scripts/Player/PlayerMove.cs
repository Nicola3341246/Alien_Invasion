using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Rigidbody2D self;
    [SerializeField] Animator playerAnimator;
    Vector2 directions;     

    [SerializeField] Transform playerSword;
    [SerializeField] Vector2 attackRange;
    [SerializeField] LayerMask attackableLayer;
    [SerializeField] float damage;

    //Test
    [SerializeField] SpriteRenderer mySword;

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
        self.velocity = move;        
    }

    private void Attack()
    {
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

    private void FacingDirection()
    {
        // nothing
        if (directions.y != 0 || directions.x != 0)
        {
            // facing left
            if (directions.x < 0)
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
            }
        }
    }
}
