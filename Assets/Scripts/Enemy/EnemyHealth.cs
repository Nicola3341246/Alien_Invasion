using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] Vector2 startPosition;
    [SerializeField] Transform self;
    [SerializeField] GameObject enemyObject;
    [SerializeField] float enemyMaxHealth;
    public float enemyHealth;

    private void Start()
    {
        enemyHealth = enemyMaxHealth;
    }

    public void HitEnemy(float damage)
    {
        enemyHealth -= damage;

        if (enemyHealth <= 0)
        {
            self.position = startPosition;
            enemyHealth = enemyMaxHealth;
        }
    }
}
