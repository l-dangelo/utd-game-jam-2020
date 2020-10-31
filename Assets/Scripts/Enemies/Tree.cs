using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : LevelController
{
    int _health = 8;

    // Update is called once per frame
    void Update()
    {
        
    }

    void TakeDamage(int damageToTake)
    {
        _health -= damageToTake;

        if(_health <= 0)
        {
            gameObject.SetActive(false);
            LoadScene("WinScreen");
        }
    }
}
