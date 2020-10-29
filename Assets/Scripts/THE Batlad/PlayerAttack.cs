using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Attack Options")]
    [SerializeField] LayerMask hitLayers;
    public float meleeHitDistance = 5;
    

    RaycastHit2D hitRayMelee;



    // Start is called before the first frame update
    void Start()
    {
        
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
            //melee attack
            //create a small raycast, and if it hits, deal damage
            Debug.DrawRay(transform.position, transform.forward, Color.green, 5);
            hitRayMelee = Physics2D.Raycast(transform.position, transform.forward, meleeHitDistance);

            if (hitRayMelee.collider != null)
            {
                if (hitRayMelee.collider.CompareTag("Enemy"))
                {
                    //Do damage
                }
            }

            }
        }
}
