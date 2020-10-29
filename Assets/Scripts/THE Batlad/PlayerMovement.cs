using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Character Controller")]
    [SerializeField] Rigidbody2D rb = null;
    

    [Header("Movement Options")]
    [SerializeField] float _moveSpeed = 5;
    [SerializeField] float _jumpForce = 5;
    [SerializeField] int _maxJumps = 3;
    int jumpCounter = 1;

    [Header("Groundcheck Options")]
    [SerializeField] Transform groundCheck = null;
    [SerializeField] LayerMask groundMask;
    //public int _groundDistance;
    public float boxDiameter = 0.5f;

    bool isGrounded;

    private void Awake()
    {
        groundMask = LayerMask.GetMask("Ground");
    }


    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        //TODO ADD ANIMATION
        //animator.SetBoolean("Walking", true);

        //UHH I gotta try to import movement thru vector2's lets gooo
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 _moveDirection = transform.right * x; //find the move direction based on axis buttons pressed times their respective transforms
        transform.position += _moveDirection * _moveSpeed * Time.deltaTime; //this right here multiplies the move direction by a set moveSpeed and then multiplies it by the completion time (in seconds) since the last frame, and moves the CC
    }

    void Jump()
    {
        isGrounded = Physics2D.OverlapBox(groundCheck.position, new Vector2(boxDiameter - 0.1f, boxDiameter - 0.1f), 90, groundMask);

        //Debug.Log("Player is Grounded: " + isGrounded);

        if (isGrounded)
        {
            jumpCounter = 1;
        }

        if (Input.GetButtonDown("Jump")){
            jumpCounter++;
            if (jumpCounter <= _maxJumps) //allow up to MAXJUMPS # of jumps
            {
                rb.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Impulse); //add jump force
            }
        }
    }
}
