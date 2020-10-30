using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeHit : MonoBehaviour
{
    public bool HitSomething; //if it hit anything
    public bool HitEnemy; //if that thing is an enemy
    public bool HitWall; //if that thing is a wall
    public Collider2D thingHit;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.attachedRigidbody != null)
        {
            HitSomething = true;
            if (collision.tag.Equals("Enemy"))
            {
                Debug.Log("Hit Enemy");

                HitEnemy = true;

            }

            if (collision.tag.Equals("Destructible Wall"))
            {
                Debug.Log("Hit Wall");

                HitWall = true;

            }
        }
       if (collision.attachedRigidbody == null)
        {
            Debug.Log("Missed!");
            HitSomething = false;
        }
            
    }
}
