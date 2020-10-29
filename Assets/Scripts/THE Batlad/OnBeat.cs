using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBeat : MonoBehaviour
{
    // Set to true if the player is on beat. False if they are not
    public bool _isOnBeat = false;

    // the amount of beats the player has been "On Beat"
    public int _beatCounter = 0;

    int updateCounter = 1;

    // Called 50 times a second
    private void FixedUpdate()
    {
        /* 
         * Space should be hit on updates 1 and 26.
         * There are 50 updates a second and we need 2.
         * updateCounter should be reset to 1 after update 50.
         */
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(updateCounter == 1 || updateCounter == 26)
            {
                OnBeatSuccess();
            }
            else
            {
                OnBeatFail();
            }
        }
        else if ((updateCounter == 1 || updateCounter == 26) && !(Input.GetKeyDown(KeyCode.Space)))
        {
            OnBeatFail();
        }

        updateCounter++;
        if(updateCounter == 51)
        {
            updateCounter = 1;
        }
    }

    // Called if the player hit space in time. Increments the beat counter
    void OnBeatSuccess()
    {
        _isOnBeat = true;
        _beatCounter++;
    }


    // Called if the player doesn't hit the space. Sets the beat count to zero and the bool to false
    void OnBeatFail()
    {
        _isOnBeat = false;
        _beatCounter = 0;
    }
}