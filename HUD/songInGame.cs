using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class songInGame : MonoBehaviour
{
    [SerializeField] private Slider _VolumeSlider;
    [SerializeField] private AudioMixer _Mixer;
    
    [SerializeField] private float _Maxdecibel;
    float Calcul;
    private void Awake()
    {
        //_VolumeSlider.value = _BaseVolume;
        //float VolumeMax = (_Maxdecibel * _VolumeSlider.value * 2);
        //_Mixer.SetFloat("Volume", (VolumeMax));
        _Mixer.GetFloat("Volume",out float ActualVolume);
        _VolumeSlider.value = (ActualVolume + _Maxdecibel + 2 / 2 * _Maxdecibel);

    }
    private void Start()
    {
        _Mixer.GetFloat("Volume", out float ActualVolume);
        Calcul = (ActualVolume + _Maxdecibel + 2);
        Calcul /= 2 * _Maxdecibel;
        _VolumeSlider.value = Calcul;
        
        Debug.Log((Calcul));  
    }
    public void ChangeVolume()
    {
        float VolumeMax = (_Maxdecibel * _VolumeSlider.value * 2) - (_Maxdecibel + 2);
        _Mixer.SetFloat("Volume", (VolumeMax));

    }
}
