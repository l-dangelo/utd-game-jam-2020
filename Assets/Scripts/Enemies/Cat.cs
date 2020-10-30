﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public float _moveSpeed = 1;
    public bool isFacingRight = true;
    int hitWallInt = 1; // negate when hit wall
    public BoxCollider2D boxCollider;

    RaycastHit2D hitRay;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        //if (checkOnBeat())
        //{
        Vector3 _moveDirection = transform.right * hitWallInt;
        transform.position += _moveDirection * _moveSpeed * Time.fixedDeltaTime;
        //}

        CheckForFall();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Wall") || collision.tag.Equals("Destructible Wall"))
        {
            hitWallInt = -hitWallInt;
            Flip();
        }
        if (collision.tag.Equals("Player"))
        {
            Debug.Log("Hit Player");
            //Reduce time by [TIME]
        }
    }

    void CheckForFall()
    {
        float right = transform.position.x + (boxCollider.size.x * transform.localScale.x / 2.0f) + (boxCollider.offset.x * transform.localScale.x) - 0.1f;
        Vector2 _foresight = new Vector2(right, transform.position.y - (boxCollider.bounds.extents.y + 0.05f));

        Debug.DrawRay(_foresight, Vector2.down, Color.cyan);
        //Right ray start X ;
        hitRay = Physics2D.Raycast(_foresight, Vector2.down, 2);

        if (hitRay.collider == null)
        {
            hitWallInt = -hitWallInt;
            Flip();
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
