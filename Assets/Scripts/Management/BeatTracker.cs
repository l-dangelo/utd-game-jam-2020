using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeatTracker : OnBeat
{
    [Header("Pictures")]
    [SerializeField] GameObject _onBeatImage = null;
    [SerializeField] GameObject _offBeatImage = null;


    private void FixedUpdate()
    {
        if (CheckOnBeat())
        {
            _offBeatImage.SetActive(false);
            _onBeatImage.SetActive(true);
        }
        else
        {
            _onBeatImage.SetActive(false);
            _offBeatImage.SetActive(true);
        }
    }
}