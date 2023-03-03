using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] float damage;

    public void OnTriggerEnter2D(Collider2D other)
    {
        try
        {
            other.GetComponent<EnemyHealth>().HitEnemy(damage);
        }
        catch (System.Exception)
        {


        }
        Destroy(gameObject);
    }
}
