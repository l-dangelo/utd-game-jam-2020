using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Character Settings")]
    [SerializeField] Rigidbody2D rb = null;
    [SerializeField] Animator animator = null;


    [Header("Movement Options")]
    [SerializeField] public float _moveSpeed = 5;
    [SerializeField] float _jumpForce = 5;
    [SerializeField] int _maxJumps = 3;
    int jumpCounter = 0;

    [Header("Groundcheck Options")]
    [SerializeField] Transform groundCheck = null;
    [SerializeField] LayerMask groundMask;
    //public int _groundDistance;
    public float boxDiameter = 0.5f;
    public float x;

    bool isGrounded;
    public bool isFacingRight = true;

    private void Awake()
    {
        groundMask = LayerMask.GetMask("Ground");
        animator = GetComponentInChildren<Animator>();
        animator.SetInteger("jumpNumber", 0);
    }


    void Update()
    {
        Move();
        Jump();
        GroundCheck();
    }

    void GroundCheck()
    {
        isGrounded = Physics2D.OverlapBox(groundCheck.position, new Vector2(boxDiameter - 0.1f, boxDiameter - 0.1f), 90, groundMask);

        if (isGrounded)
        {
            animator.SetBool("isGrounded", true);
        }
        else if (!isGrounded)
        {
            animator.SetBool("isGrounded", false);

        }
    }

    void Move()
    {
        //TODO ADD ANIMATION
        //animator.SetBoolean("Walking", true);

        //UHH I gotta try to import movement thru vector2's lets gooo
        x = Input.GetAxis("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(x * _moveSpeed));

        Vector3 _moveDirection = transform.right * x; //find the move direction based on axis buttons pressed times their respective transforms
        transform.position += _moveDirection * _moveSpeed * Time.deltaTime; //this right here multiplies the move direction by a set moveSpeed and then multiplies it by the completion time (in seconds) since the last frame, and moves the CC

        //flip the sprite depending on direction

        if (x < 0 && isFacingRight) Flip();
        if (x > 0 && !isFacingRight) Flip();


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

    
}
