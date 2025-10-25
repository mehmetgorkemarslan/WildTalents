using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerController : MonoBehaviour
{
    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int Jump = Animator.StringToHash("Jump");

    protected Rigidbody2D rb;
    protected Animator animator;
    protected SpriteRenderer spriteRenderer;
    
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (rb == null || animator == null || spriteRenderer == null)
        {
            Debug.LogError("PlayerController: Gerekli bileşenler (Rigidbody2D/Animator/SpriteRenderer) bulunamadı!");
        }
    }
    
    protected virtual void Update()
    {
        HandleMovement();
        HandleJump();
        HandleSuperPowerInput();
    }

    private void HandleMovement()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        animator.SetFloat(Speed, moveInput);
    }

    //TODO: Zıplama mekaniği force üzerinde olsun ve yer kontrolü ekle
    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump") )
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetTrigger(Jump);
        }
    }

    public abstract void UseSuperPower();
    
    protected virtual void HandleSuperPowerInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            UseSuperPower();
        }
    }
}
