using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] GameObject enemyObject;
    [SerializeField] float enemyMaxHealth;
    float enemyHealth;

    private void Start()
    {
        enemyHealth = enemyMaxHealth;
    }

    public void HitEnemy(float damage)
    {
        enemyHealth -= damage;

        if (enemyHealth <= 0)
        {
            enemyObject.SetActive(false);
        }
    }
}
