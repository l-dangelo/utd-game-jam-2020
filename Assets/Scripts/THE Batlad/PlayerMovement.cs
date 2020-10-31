using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : OnBeat
{
    [Header("Character Settings")]
    [SerializeField] Rigidbody2D rb = null;
    [SerializeField] Animator animator = null;
    [SerializeField] ParticleSystem dustSystem = null;


    [Header("Movement Options")]
    [SerializeField] public float _moveSpeed = 5;
    [SerializeField] float _jumpForce = 5;
    [SerializeField] int _maxJumps = 3;
    int jumpCounter = 0;

    [Header("Groundcheck Options")]
    [SerializeField] Transform groundCheck = null;
    [SerializeField] Transform CielingCheck = null;
    [SerializeField] LayerMask groundMask;
    //public int _groundDistance;
    public float boxDiameter = 0.5f;
    public float x;

    [Header("Audio")]
    [SerializeField] AudioSource _hurtSound = null;
    [SerializeField] AudioSource _flapSound = null;
    [SerializeField] AudioSource _moveSound = null;

    bool isGrounded;
    bool touchedCieling;
    public bool isFacingRight = true;
    public bool hitByEnemy = false;
    public Vector3 _moveDirection;

    private void Awake()
    {
        groundMask = LayerMask.GetMask("Ground");
        animator = GetComponentInChildren<Animator>();
        animator.SetInteger("jumpNumber", 0);
    }

    private void Update()
    {
        Move();
        Jump();
        GroundCheck();

        //Debug.Log(rb.velocity.x + " and " + rb.velocity.y);
        if (hitByEnemy)
        {
            StartCoroutine(HitByEnemy());
            
        }

    }

    private void FixedUpdate()
    {
        JumpOnBeat();
    }

    void GroundCheck()
    {
        isGrounded = Physics2D.OverlapBox(groundCheck.position, new Vector2(boxDiameter - 0.1f, boxDiameter - 0.1f), 90, groundMask);

        if (isGrounded)
        {
            //Debug.Log("Is Grounded");
            animator.SetBool("isGrounded", true);
        }
        else if (!isGrounded)
        {
            animator.SetBool("isGrounded", false);
            dustSystem.Stop();
        }
    }

    void CeilingCheck()
    {
        touchedCieling = Physics2D.OverlapBox(CielingCheck.position, new Vector2(boxDiameter - 0.1f, boxDiameter - 0.1f), 90, groundMask);

        if (touchedCieling)
        {
            rb.velocity.Set(x, 0);
        }
    }

    void Move()
    {
        _moveSound.Play();
        //TODO ADD ANIMATION
        //animator.SetBoolean("Walking", true);

        //UHH I gotta try to import movement thru vector2's lets gooo
        x = Input.GetAxis("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(x * _moveSpeed));

        _moveDirection = transform.right * x; //find the move direction based on axis buttons pressed times their respective transforms
        transform.position += _moveDirection * _moveSpeed * Time.deltaTime; //this right here multiplies the move direction by a set moveSpeed and then multiplies it by the completion time (in seconds) since the last frame, and moves the CC

        //flip the sprite depending on direction

        if (x < 0 && isFacingRight) Flip();
        if (x > 0 && !isFacingRight) Flip();

        if (isGrounded)
        {
            if(Mathf.Abs(x * _moveSpeed) > 0)
            {
                    dustSystem.Play();
            }
            else
            {
                dustSystem.Stop();
            }
        }


    }

    void Jump()
    {
        //Debug.Log("Player is Grounded: " + isGrounded);
        animator.SetInteger("jumpNumber", jumpCounter);

        if (isGrounded) 
        {
            jumpCounter = 0;
        }

        //CHECK VERTICAL SPEED AND APPLY FALLING IF NEGATIVE
        if (rb.velocity.y < -2)
        {
            animator.SetBool("isJumping", false);
        }
               
        if (Input.GetButtonDown("Jump")){
            jumpCounter++;
            //animator.SetInteger("jumpNumber", jumpCounter);
            animator.SetBool("isJumping", true);
            if (jumpCounter <= _maxJumps -1 && !animator.GetBool("isAttacking")) //allow up to MAXJUMPS # of jumps
            {
                rb.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Impulse); //add jump force
                
            }

        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void JumpOnBeat()
    {
        if (CheckOnBeat())
        {
            if (Input.GetKey(KeyCode.Space))
            {
                OnBeatSuccess();
            }
            else
            {
                OnBeatFail();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            OnBeatFail();
        }
    }

    IEnumerator HitByEnemy()
    {
        _hurtSound.Play();
        hitByEnemy = false;
        rb.velocity = new Vector2(0, 0);
        rb.gravityScale = 0.9f;
        _moveSpeed /= 3;
        if (isFacingRight)
            rb.AddForce(new Vector2(-_jumpForce / 3, _jumpForce / 3), ForceMode2D.Impulse);

        if (!isFacingRight)
            rb.AddForce(new Vector2(_jumpForce / 3, _jumpForce / 3), ForceMode2D.Impulse);

        animator.SetTrigger("isHit");
        animator.SetBool("isBeingHit", true);

        yield return new WaitForSeconds(1f);

        animator.SetBool("isBeingHit", false);
        rb.gravityScale = 1;
        _moveSpeed *= 3;
        
    }
}
