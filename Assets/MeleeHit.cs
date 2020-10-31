using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MeleeHit : MonoBehaviour
{
    [SerializeField] PlayerAttack playerAttack = null;
    [SerializeField] Animator animator = null;
    [SerializeField] ParticleSystem damageBurst = null;
    [SerializeField] ParticleSystem enemyBurst = null;
    BoxCollider2D collBox;


    public bool HitSomething; //if it hit anything
    public bool HitEnemy; //if that thing is an enemy
    public bool HitWall; //if that thing is a wall


    private void Awake()
    {
        playerAttack = GetComponentInParent<PlayerAttack>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collided");
        HitSomething = true;

        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Debug.Log("Hit Enemy");
            enemyBurst = collision.GetComponentInChildren<ParticleSystem>();

            Debug.Log("Hit Enemy For Sure");
            animator.SetBool("hitEnemy", true);

            DelayHelper.DelayAction(playerAttack, playerAttack.Bounce, playerAttack.animationLength);
            damageBurst.Play();

            if (enemyBurst != null) enemyBurst.Play();
            HitEnemy = true;

            if (collision.CompareTag("Ghost")) //is it a ghost?
            {
                //do nothing
                collBox = collision.gameObject.GetComponent<BoxCollider2D>();
                collBox.isTrigger = false;

               
                Debug.Log("Hit Ghost!...it wasn't very effective");
            }

            if (collision.CompareTag("Punkin")) //is it a punkin?
            {
                Debug.Log("Hit Punkin!");
                //add time [TIME]

                collBox = collision.gameObject.GetComponent<BoxCollider2D>();
                collBox.enabled = false;

                Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
                rb.AddForce(new Vector2(1, 4), ForceMode2D.Impulse);
                rb.gravityScale = 2;
                if (rb.velocity.y <= -2) //this needs fixing
                {
                    Destroy(collision.gameObject);
                    Debug.Log("GameObject Destroyed");
                }
            }

            if (collision.CompareTag("Cat")) //is it a punkin?
            {
                Debug.Log("Hit Cat!");

                //add time [TIME]

                collBox = collision.gameObject.GetComponent<BoxCollider2D>();
                collBox.enabled = false;

                Rigidbody2D rb2 = collision.gameObject.GetComponent<Rigidbody2D>();
                rb2.AddForce(new Vector2(1, 4), ForceMode2D.Impulse);
                rb2.gravityScale = 2;
                if (rb2.velocity.y <= -2) //this needs fixing
                {
                    Destroy(collision.gameObject);
                    Debug.Log("GameObject Destroyed");
                }
            }

            if (collision.CompareTag("Spider")) //is it a punkin?
            {
                Debug.Log("Hit Spider!");

                //add time [TIME]

                collBox = collision.gameObject.GetComponent<BoxCollider2D>();
                collBox.enabled = false;


                Rigidbody2D rb3 = collision.gameObject.GetComponentInParent<Rigidbody2D>();
                rb3.AddForce(new Vector2(1, 4), ForceMode2D.Impulse);
                rb3.gravityScale = 2;
                if (rb3.velocity.y <= -2) //this needs fixing
                {
                    Destroy(collision.gameObject);
                    Debug.Log("GameObject Destroyed");
                }

            }

            if (collision.tag.Equals("Destructible Wall"))
            {
                Debug.Log("Hit Wall");
                //Destroy wall and replace with gravity-affected rigidbody prefab
                //Destroy prefab after 3 seconds

                HitWall = true;

            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            collBox = collision.gameObject.GetComponent<BoxCollider2D>();
            collBox.enabled = true;
            collBox.isTrigger = true;
        }
    }

}//end of class
