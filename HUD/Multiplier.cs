using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Multiplier : MonoBehaviour
{
    [Header("Multiplier")]
    public List<Sprite> _Multiplier;

    [Header("Slider")]
    [SerializeField] private float _BaseSpeedSlider;
    public List<Image> _SliderImage = new List<Image>();
    public AnimationClip _Clip;
    private Animator _Animator;
    private float _ModifiedSpeed;
    private Image _MultiplierImage;
    private Slider _MultiplierSlider;
    private int _ActualIcons;

    private bool _DoIHaveAnImage;
    private Coroutine _FailImage;


    // Start is called before the first frame update
    void Start()
    {
        _Animator = GetComponent<Animator>();
        _MultiplierImage = GetComponentInChildren<Image>();
        _MultiplierSlider = GetComponentInChildren<Slider>();

        _MultiplierSlider.value = 0;

        _MultiplierImage.color = Color.clear;

        foreach (var item in _SliderImage) { item.color = Color.clear; }
    }
    #region IconsMultiplier
    public void ActiveMultiplicateur()
    {
        if (_ActualIcons == 0 & _MultiplierImage.color != Color.clear)
        {
            _MultiplierImage.color = Color.clear;
        }
        _ActualIcons = Mathf.Clamp(_ActualIcons += 1, 0, 5);
        _MultiplierSlider.value = 1;
        if (_ActualIcons != 0)
        {
            _ModifiedSpeed = Mathf.Clamp(_BaseSpeedSlider * (_Multiplier.IndexOf(_Multiplier[_ActualIcons])), 0.1f, 0.5f);
            
        }

        _MultiplierImage.color = Color.white;
        _MultiplierImage.sprite = _Multiplier[_ActualIcons];
        _Animator.SetTrigger("Anim");
    }
    IEnumerator AnimBeforeLostMultiplie()
    {
        _Animator.SetTrigger("Lost");
        yield return new WaitForSecondsRealtime(_Clip.length);
        _ActualIcons = 0;
        _MultiplierImage.color = Color.clear;
        _MultiplierImage.sprite = _Multiplier[_ActualIcons];
        _MultiplierSlider.value = 0;
        _ModifiedSpeed = _BaseSpeedSlider;
        foreach (var item in _SliderImage) { item.color = Color.clear; }
        _FailImage = null;
    }
    public void LostYourMultiplie()
    {
       if (_FailImage == null)
        {
            _FailImage = StartCoroutine(AnimBeforeLostMultiplie());
            _ActualIcons = 0;
        }
    
      
       // Debug.Log("multiple bug");
    }


    #endregion

    #region Slide Multiplier

    public void SliderMultiplier()
    {
        if (_MultiplierSlider.value != 0)
        {
            if (_SliderImage[0].color == Color.clear) { foreach (var item in _SliderImage) { item.color = Color.white; } }
            _MultiplierSlider.value = Mathf.Clamp(_MultiplierSlider.value -= Time.deltaTime * _ModifiedSpeed, 0, 1);
        }
        if( _MultiplierSlider.value == 0 && _Multiplier.IndexOf(_Multiplier[_ActualIcons]) != 0) { LostYourMultiplie(); }
       // Debug.Log("SliderBug");
    }

    #endregion


    #region CurrentMultiplier

    public float CurrentMultiplier()
    {
        float ActualMultiplie = 0;
        ActualMultiplie = _Multiplier.IndexOf(_Multiplier[_ActualIcons]);
            //ModifiedSpeed * 10;
            //ActualMultiplie = Mathf.Clamp( _Multiplier.IndexOf(_Multiplier[_ActualIcons]),1,5); // _ModifiedSpeed * 10;
            // Debug.Log(_Multiplier.IndexOf(_Multiplier[_ActualIcons]));


        if (_Multiplier.IndexOf(_Multiplier[_ActualIcons]) >= 0)
        {
            ActualMultiplie++;
        }
       // Debug.Log((_Multiplier[_ActualIcons]));
        //Debug.Log((_Multiplier.IndexOf(_Multiplier[_ActualIcons])));
        return ActualMultiplie;
    }
    #endregion
    private void Update()
    {
        if (Time.timeScale != 0)
        {
            SliderMultiplier();

        }

    }
}
