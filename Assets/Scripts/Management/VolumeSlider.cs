using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] AudioMixer _mixer = null;
    [SerializeField] Slider _slider = null;

    public void SetVolume()
    {
        float sliderValue = _slider.value;
        _mixer.SetFloat("MainSongVolume", Mathf.Log10(sliderValue) * 20);
    }
}
