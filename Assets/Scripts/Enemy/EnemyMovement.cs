using System.Collections;
using System.Diagnostics;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float attackCooldown;
    Stopwatch cooldown = new Stopwatch();

    [SerializeField] Transform playerPosition;
    [SerializeField] Transform selfPosition;
    [SerializeField] Transform sword;
    [SerializeField] Animator enemyAnimator;

    [SerializeField] LayerMask playerLayer;
    [SerializeField] Vector2 attackRange;
    [SerializeField] float damage;

    void Update()
    {
        FacingPosition();
        AttackPlayer();
    }

    private void FacingPosition()
    {
        float relativPositionX = selfPosition.position.x - playerPosition.position.x;
        float relativPositionY = selfPosition.position.y - playerPosition.position.y;
        // up
        if (relativPositionY < 0 && (relativPositionX / relativPositionY) > -1 && (relativPositionX / relativPositionY) < 1)
        {
            enemyAnimator.SetFloat("Horizontal", 0);
            enemyAnimator.SetFloat("Vertical", 1);
        }
        // down
        else if (relativPositionY > 0 && (relativPositionX / relativPositionY) > -1 && (relativPositionX / relativPositionY) < 1)
        {
            enemyAnimator.SetFloat("Horizontal", 0);
            enemyAnimator.SetFloat("Vertical", -1);
        }
        // left
        else if (relativPositionX > 0)
        {
            enemyAnimator.SetFloat("Horizontal", -1);
            enemyAnimator.SetFloat("Vertical", 0);
        }
        // right
        else if (relativPositionX < 0)
        {
            enemyAnimator.SetFloat("Horizontal", 1);
            enemyAnimator.SetFloat("Vertical", 0);
        }
    }

    private void AttackPlayer()
    {
        if (Vector2.Distance(selfPosition.position, playerPosition.position) < 2)
        {
            cooldown.Start();

            if (cooldown.ElapsedMilliseconds > attackCooldown)
            {
                cooldown.Restart();
                Collider2D[] hitEnemy = Physics2D.OverlapBoxAll(sword.position, attackRange, playerLayer);
                foreach (Collider2D item in hitEnemy)
                {
                    try
                    {
                        item.GetComponent<PlayerHealth>().DamagePlayer(damage);
                    }
                    catch (System.Exception) { }
                }
            }
        }
        else
        {
            cooldown.Stop();
            cooldown.Reset();
        }
    }
}
