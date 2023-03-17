using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField] Transform heartTransform;
    [SerializeField] float healRange;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] float heal;

    // Update is called once per frame
    void Update()
    {
        Collider2D[] healPlayer = Physics2D.OverlapCircleAll(heartTransform.position, healRange, playerLayer);
        foreach (Collider2D item in healPlayer)
        {
            try
            {
                item.GetComponent<PlayerHealth>().HealPlayer(heal);
            }
            catch (System.Exception) { }
        }
    }
}
