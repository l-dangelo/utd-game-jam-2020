using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeHit : MonoBehaviour
{
    [SerializeField] PlayerAttack playerAttack = null;
    [SerializeField] Animator animator = null;
    [SerializeField] ParticleSystem damageBurst = null;
    [SerializeField] ParticleSystem enemyBurst = null;


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

            if (collision.tag.Equals("Enemy"))
            {
                Debug.Log("Hit Enemy");
                enemyBurst = collision.GetComponentInChildren<ParticleSystem>();

                Debug.Log("Hit Enemy For Sure");
                animator.SetBool("hitEnemy", true);

                DelayHelper.DelayAction(playerAttack, playerAttack.Bounce, playerAttack.animationLength);
                damageBurst.Play();
                
                if (enemyBurst != null) enemyBurst.Play();


                HitEnemy = true;

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
