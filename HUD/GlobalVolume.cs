using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GlobalVolume : MonoBehaviour
{
    [SerializeField] private Slider _VolumeSlider;
    [SerializeField] private AudioMixer _Mixer;
    [SerializeField] private float _BaseVolume;
    [SerializeField] private float _Maxdecibel;
    [SerializeField] private float _VolumeSubstract;
    private void Awake()
    {
        _VolumeSlider.value = _BaseVolume;
        float VolumeMax = (_Maxdecibel * _VolumeSlider.value * 2) - (_Maxdecibel + 2);
        _Mixer.SetFloat("Volume", (VolumeMax));
    }

    public void ChangeVolume()
    {
        float VolumeMax= (_Maxdecibel * _VolumeSlider.value*2)-(_Maxdecibel+2);
        _Mixer.SetFloat("Volume", (VolumeMax));
       
    }
}
