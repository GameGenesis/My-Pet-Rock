using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 1;

    bool isCrouching;
    bool isFacingRight;

    float moveInput;

    Rigidbody2D rb;
    Animator animator;

    [SerializeField] AudioSource footstepSounds;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal") * speed;
        animator.SetFloat("Speed", Mathf.Abs(moveInput));

        if (Mathf.Abs(moveInput) > 0)
            footstepSounds.enabled = true;
        else
            footstepSounds.enabled = false;

        if (moveInput > 0 && !isFacingRight)
        {
            isFacingRight = true;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, 1);
        }
        else if (moveInput < 0 && isFacingRight)
        {
            isFacingRight = false;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, 1);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput, rb.velocity.y);
    }
}
