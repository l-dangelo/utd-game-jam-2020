using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipsShoot : MonoBehaviour
{
    [SerializeField] AudioSource chipShoot = null;
    [SerializeField] GameObject chip = null;
    [SerializeField] Transform gunPos = null;
    [SerializeField] Animator animator = null;

    [SerializeField] AudioSource _shootSound = null;

    public bool canShoot = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && canShoot)
        {
            _shootSound.Play();

            chipShoot.PlayOneShot(chipShoot.clip, 2);
            animator.SetTrigger("ThrowAttack");
            animator.SetBool("isThrowing", true);
            Instantiate(chip, gunPos.position, Quaternion.identity);
            Debug.Log("Player Shoot!");
            canShoot = false;

            DelayHelper.DelayAction(this, MoveOn, 0.05f);
        }
    }

    void MoveOn()
    {
        animator.SetBool("isThrowing", false);
    }
    
}
