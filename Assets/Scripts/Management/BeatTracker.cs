using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeatTracker : OnBeat
{
    [Header("Pictures")]
    [SerializeField] GameObject _onBeatImage = null;
    [SerializeField] GameObject _offBeatImage = null;

    int updateCounter = 1;

    private void FixedUpdate()
    {

        if(updateCounter == 1 || updateCounter == 26)
        {
            _offBeatImage.SetActive(false);
            _onBeatImage.SetActive(true);
        }
        else
        {
            _onBeatImage.SetActive(false);
            _offBeatImage.SetActive(true);
        }

        updateCounter++;
        if (updateCounter == 50)
        {
            updateCounter = 1;
        }
    }
}