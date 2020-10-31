using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    public AudioClip hitPSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            Debug.Log("Hit Player");
            AudioHelper.PlayClip2D(hitPSound, 1);
            //Reduce time by [TIME]
            PlayerMovement playerMove = collision.GetComponentInParent<PlayerMovement>();
            playerMove.hitByEnemy = true;
        }
    }
}
