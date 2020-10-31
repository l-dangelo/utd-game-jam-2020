using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipsShoot : MonoBehaviour
{
    [SerializeField] AudioSource chipShoot = null;
    [SerializeField] GameObject chip = null;
    [SerializeField] Transform gunPos = null;

    public bool canShoot = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && canShoot)
        {
            chipShoot.PlayOneShot(chipShoot.clip, 2);
            Instantiate(chip, gunPos.position, Quaternion.identity);
            Debug.Log("Player Shoot!");
            canShoot = false;
        }
    }
    
}
