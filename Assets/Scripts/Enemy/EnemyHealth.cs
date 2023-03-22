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

    [SerializeField] GameObject healthbar;
    [SerializeField] GameObject Supervisor;

    private void Start()
    {
        enemyHealth = enemyMaxHealth;
    }

    public void HitEnemy(float damage)
    {
        enemyHealth -= damage;
        healthbar.GetComponent<SliderHorizontal>().SetSlider((enemyHealth * 100) / enemyMaxHealth);

        if (enemyHealth <= 0)
        {
            self.position = startPosition;
            enemyHealth = enemyMaxHealth;
            healthbar.GetComponent<SliderHorizontal>().SetSlider(100f);
            Supervisor.GetComponent<GameSupervisor>().ChangeKillScore(1f);
        }
    }
}
