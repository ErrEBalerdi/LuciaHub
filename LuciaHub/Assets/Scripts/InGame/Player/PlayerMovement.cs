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
    private Animator Animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Tomar el input del usuario. Una vez por frame.
        horizontalInput = Input.GetAxisRaw("Horizontal");
        if (horizontalInput < 0.0f) { transform.localScale = new Vector3 (-0.4770458f, 0.4546192f, 1.0f); }
        else if (horizontalInput > 0.0f) { transform.localScale = new Vector3(0.4770458f, 0.4546192f, 1.0f); }
        Animator.SetBool("walking", horizontalInput != 0.0f);
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
