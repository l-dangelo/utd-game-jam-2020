using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipBullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb = null;
    [SerializeField] ParticleSystem enemyBurst = null;
    [SerializeField] GameObject player = null;
    BoxCollider2D collBox;
    public float shootForceX = 20;
    public float shootForceY = 10;
    


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        Rigidbody2D playerRB = player.GetComponent<Rigidbody2D>();

        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();

        //shootForceX *= playerRB.velocity.x;
        //shootForceY *= playerRB.velocity.y;

        shootForceX = playerMovement._moveDirection.x + 5;

        if (playerMovement.isFacingRight)
        {
            rb.AddForce(new Vector2(shootForceX, shootForceY), ForceMode2D.Impulse);
        }

        if (!playerMovement.isFacingRight)
        {
            rb.AddForce(new Vector2(-shootForceX, shootForceY), ForceMode2D.Impulse);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collided");

        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Debug.Log("Hit Enemy");
            enemyBurst = collision.GetComponentInChildren<ParticleSystem>();

            if (enemyBurst != null) enemyBurst.Play();

            if (collision.CompareTag("Ghost")) //is it a ghost?
            {
                //do nothing


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

            }

        }
    }
}
