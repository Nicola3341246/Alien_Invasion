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
    [SerializeField] float meleDamage;

    [SerializeField] SpriteRenderer mySword;
    [SerializeField] float attackcooldown;
    Stopwatch meleCooldown = new Stopwatch();

    [SerializeField] AudioSource walksound;
    [SerializeField] AudioSource shotsound;
    [SerializeField] AudioSource attacksound;

    [SerializeField] GameObject weapon;
    [SerializeField] float gunDamage;
    [SerializeField] GameObject gun;
    [SerializeField] Animator gunAnimator;

    Stopwatch gunCooldown = new Stopwatch();
    [SerializeField] float gunCooldownTime;

    private void Start()
    {
        meleCooldown.Start();
        gunCooldown.Start();
    }

    void Update()
    {
        directions.x = Input.GetAxis("Horizontal");
        directions.y = Input.GetAxis("Vertical");

        if (Input.GetMouseButtonDown(1))
        {
            Attack();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        Move();
        FacingDirection();
    }

    private void Move()
    {
        Vector2 move;
        move.x = directions.x * moveSpeed;
        move.y = directions.y * moveSpeed;

        if (move.x > 0 || move.y > 0 || move.x < 0 || move.y < 0) { walksound.enabled = true; }
        else { walksound.enabled = false; }

        playerAnimator.SetFloat("Speed", move.magnitude);
        self.velocity = move;        
    }

    private void Attack()
    {
        if (meleCooldown.ElapsedMilliseconds > attackcooldown)
        {
            meleCooldown.Restart();
            playerAnimator.Play("Attack");
            attacksound.Play();

            Collider2D[] hitEnemy = Physics2D.OverlapBoxAll(playerSword.position, attackRange, attackableLayer);
            foreach (Collider2D item in hitEnemy)
            {
                try
                {
                    item.GetComponent<EnemyHealth>().HitEnemy(meleDamage);
                }
                catch (System.Exception) { }
            }
        }
    }

    private void Shoot()
    {
        if (gun.active && gunCooldown.ElapsedMilliseconds > gunCooldownTime)
        {
            gunCooldown.Restart();

            shotsound.Play();
            weapon.GetComponent<WeaponShoot>().Fire(gunDamage);
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

        float angle = AngleBetweenPoints(playerPosition, mousePosition);
        gun.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        gunAnimator.SetFloat("Horizontal", RotatAnimation.x);
        gunAnimator.SetFloat("Vertical", RotatAnimation.y);
    }

    private static float AngleBetweenPoints(Vector2 a, Vector2 b)
    {
        b.x = b.x * 0.9999f;
        b.y = b.y * 0.9999f;
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
