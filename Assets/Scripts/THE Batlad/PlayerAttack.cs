using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Character Options")]
    [SerializeField] Rigidbody2D rb = null;

    [Header("Animation Options")]
    [SerializeField] Animator animator = null;
    public float animationLength = 0.6f;

    [Header("Attack Options")]
    [SerializeField] LayerMask hitLayers;
    [SerializeField] GameObject hitBox = null;
    [SerializeField] MeleeHit hitScript = null;
    public Animation anim;
    public float meleeHitDistance = 5;
    public float _bounceOffForce = 3;
    float fireRate = 1;
    public float nextAttack = 0.5f;


    RaycastHit2D hitRayMelee;
    PlayerMovement playerMovement = null;

    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        //anim = gameObject.GetComponentInChildren<Animation>();
    }

    // Update is called once per frame


    void Update()
    {
        Attack();
    }

    void Attack()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //animator.SetBool("isAttacking", true);

            //melee attack
            //create a small raycast, and if it hits, deal damage
            if (Time.time > nextAttack)
            {
                
                StartCoroutine(MeleeAttack());

                if (hitScript.HitSomething == false)
                    animator.SetBool("hitEnemy", false);
                nextAttack = Time.time + fireRate;
            }
        }

    } //end of Attack funct

    public void Bounce()
    {
        rb.AddForce(new Vector2(0f, _bounceOffForce), ForceMode2D.Impulse); //add jump force
        hitScript.HitSomething = false;
    }

    IEnumerator MeleeAttack()
    {
        //anim.Play("Player_Attack");
        animator.SetBool("isAttacking", true);
        animator.SetTrigger("Attack");
        hitBox.SetActive(true);
        rb.gravityScale = 0;
        rb.velocity = new Vector2(0, 0);
        playerMovement._moveSpeed /= 3;

        yield return new WaitForSeconds(animationLength); //anim["Player_Attack"].length

        animator.SetBool("isAttacking", false);
        animator.SetBool("hitEnemy", false);
        hitScript.HitSomething = false;
        hitBox.SetActive(false);
        rb.gravityScale = 1;
        playerMovement._moveSpeed *= 3;
    }
}
