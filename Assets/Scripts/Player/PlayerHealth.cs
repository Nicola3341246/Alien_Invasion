using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float playerMaxHealth;
    [SerializeField] Healthbar healthbar;
    float playerCurrentHealth;


    void Start()
    {
        playerCurrentHealth = playerMaxHealth;
        healthbar.SetMaxHealth(playerMaxHealth);
    }

    public void DamagePlayer(float damge)
    {
        playerCurrentHealth -= damge;
        Debug.Log($"{playerCurrentHealth}");
        healthbar.SetHealth(playerCurrentHealth);
        if (playerCurrentHealth <= 0)
        {
            PlayerDead();
        }
    }
    
    private void PlayerDead()
    {
        Debug.Log("You dead");
    }
}
