using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float playerMaxHealth;
    float playerCurrentHealth;


    void Start()
    {
        playerCurrentHealth = playerMaxHealth;
    }

    public void DamagePlayer(float damge)
    {
        playerCurrentHealth -= damge;
        Debug.Log($"{playerCurrentHealth}");
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
