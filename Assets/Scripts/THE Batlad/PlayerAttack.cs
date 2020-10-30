using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Character Options")]
    [SerializeField] Rigidbody2D rb = null;

    [Header("Animation Options")]
    [SerializeField] Animator animator = null;
    public float animationLength = 1;

    [Header("Attack Options")]
    [SerializeField] LayerMask hitLayers;
    [SerializeField] GameObject hitBox = null;
    [SerializeField] MeleeHit hitScript = null;
    public float meleeHitDistance = 5;
    public float _bounceOffForce = 3;


    RaycastHit2D hitRayMelee;
    PlayerMovement playerMovement = null;

    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
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

            StartCoroutine(MeleeAttack());

            if (hitScript.HitSomething == true)
            {
                if (hitScript.HitEnemy)
                {
                    Debug.Log("Hit Enemy");
                    animator.SetBool("hitEnemy", true);
                    rb.AddForce(new Vector2(0f, _bounceOffForce), ForceMode2D.Impulse); //add jump force
                }

                if (hitScript.HitWall)
                {
                    Debug.Log("Hit Wall");
                    //Destroy wall and replace with gravity-affected rigidbody prefab
                    //Destroy prefab after 3 seconds
                }
            } else if (hitScript.HitSomething == false)
                animator.SetBool("hitEnemy", false);
        }

    } //end of Attack funct

    IEnumerator MeleeAttack()
    {
        animator.SetBool("isAttacking", true);
        hitBox.SetActive(true);
        rb.simulated = false;
        playerMovement._moveSpeed /= 3;

        yield return new WaitForSeconds(animationLength);

        animator.SetBool("isAttacking", false);
        animator.SetBool("hitEnemy", false);
        hitBox.SetActive(false);
        rb.simulated = true;
        playerMovement._moveSpeed *= 3;
    }
}
