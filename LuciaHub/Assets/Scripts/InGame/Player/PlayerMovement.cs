using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 150f;

    public bool isFacingRight = true;

    private Rigidbody2D rb;
    private float horizontalInput;
    private Vector2 moveDirection;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Tomar el input del usuario. Una vez por frame.
        horizontalInput = Input.GetAxisRaw("Horizontal");

        // ***** Hay que cambiar los valores, muy especificos y hardcodeados *****
        if (horizontalInput < 0.0f) 
        {
            isFacingRight = false;   
            transform.localScale = new Vector3 (-0.7657424f, 0.7045414f, 1.0f); 
        }
        else if (horizontalInput > 0.0f) 
        { 
            isFacingRight = true;
            transform.localScale = new Vector3(0.7657424f, 0.7045414f, 1.0f); 
        }

        animator.SetBool("walking", horizontalInput != 0.0f);
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
