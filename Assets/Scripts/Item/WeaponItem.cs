using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : MonoBehaviour
{
    [SerializeField] Transform item;
    [SerializeField] float range;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] GameObject gun;

    void Update()
    {
        Collider2D[] healPlayer = Physics2D.OverlapCircleAll(item.position, range, playerLayer);
        foreach (Collider2D item in healPlayer)
        {
            try
            {
                gun.SetActive(true);
            }
            catch (System.Exception) { }
        }
    }
}
