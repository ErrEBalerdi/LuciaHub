using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 150f;

    private Rigidbody2D rb;
    private float horizontalInput;
    private Vector2 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Tomar el input del usuario. Una vez por frame.
        horizontalInput = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        //Todo lo relacionado a físicas en FixedUpdate
        Move();
    }

    private void Move()
    {
        moveDirection = new Vector2(horizontalInput * speed * Time.fixedDeltaTime, rb.velocity.y);
        rb.velocity = moveDirection;
    }
}
