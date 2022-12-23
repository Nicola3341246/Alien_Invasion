using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Rigidbody2D self;
    Vector2 move;

    // Update is called once per frame
    void Update()
    {
        move.x = Input.GetAxis("Horizontal") * moveSpeed;
        move.y = Input.GetAxis("Vertical") * moveSpeed;

        self.velocity = move;
    }
}
