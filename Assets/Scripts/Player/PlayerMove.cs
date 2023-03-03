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

    [SerializeField] GameObject weapon;


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
        if (Input.GetMouseButtonDown(1))
        {
            weapon.GetComponent<WeaponShoot>().Fire();
            UnityEngine.Debug.Log("OKE");
        }
        Move();
        FacingDirection();
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
            playerAnimator.Play("Attack");
            UnityEngine.Debug.Log("ds");

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
        // Wurde von hier inspiriert: https://answers.unity.com/questions/855976/make-a-player-model-rotate-towards-mouse-location.html
        Vector2 playerPosition = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 mousePosition = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        Vector2 RotatAnimation = new Vector2();
        RotatAnimation.x = (mousePosition.x - playerPosition.x) * 10f;
        RotatAnimation.y = (mousePosition.y - playerPosition.y) * 10f;
        playerAnimator.SetFloat("Horizontal", RotatAnimation.x);
        playerAnimator.SetFloat("Vertical", RotatAnimation.y);
    }
}
