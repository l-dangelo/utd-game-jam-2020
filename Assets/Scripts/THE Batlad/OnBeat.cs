using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBeat : Timer
{
    public bool _isOnBeat = false;
    public int _beatCounter = 0;
    public int updateCounter = 0;

    private void FixedUpdate()
    {
        CheckOnBeat();
    }

    public bool CheckOnBeat()
    {
        updateCounter++;
        if(updateCounter == 51)
        {
            updateCounter = 1;
        }
        
        if (updateCounter > 49 || (updateCounter > 1 && updateCounter < 3) || (updateCounter > 24 && updateCounter < 28))
        {
            return true;
        }

        return false;
    }

    public void OnBeatSuccess()
    {
        _isOnBeat = true;
        _beatCounter++;
    }

    public void OnBeatFail()
    {
        _isOnBeat = false;
        _beatCounter = 0;
    }
}