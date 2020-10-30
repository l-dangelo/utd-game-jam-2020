using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punkin : MonoBehaviour
{
    public float _moveSpeed = 1;
    public bool isFacingRight = true;
    int hitWallInt = 1; // negate when hit wall

    private void FixedUpdate()
    {
        //if (checkOnBeat())
        //{
        Vector3 _moveDirection = transform.right * hitWallInt;
        transform.position += _moveDirection * _moveSpeed * Time.fixedDeltaTime;
        //}

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Wall") || collision.tag.Equals("Destructible Wall"))
        {
            hitWallInt = -hitWallInt;
            Flip();
        }
        if (collision.tag.Equals("Player")){
            Debug.Log("Hit Player");
            //Reduce time by [TIME]
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
