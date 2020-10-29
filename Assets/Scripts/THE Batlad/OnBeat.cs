using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBeat : MonoBehaviour
{
    // Set to true if the player is on beat. False if they are not
    public bool _isOnBeat = false;

    // the amount of beats the player has been "On Beat"
    public int _beatCounter = 0;

    // Called twice a second in the Unity settings
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnBeatSuccess();
        }
        else
        {
            OnBeatFail();
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