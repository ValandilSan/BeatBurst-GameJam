using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    [SerializeField] private float _TimeForARound;

    [SerializeField] private TextMeshProUGUI _Time,_Time2;
    [SerializeField] private Image _Sprite;
    public delegate void TimerEvent();
    public static event TimerEvent EndTimer;

    private float _CurrentTime;
    private bool _IsEndGame;
    [SerializeField] EndMenu _EndMenu;
    // Start is called before the first frame update
    void Start()
    {
        // _Time = GetComponentInChildren<TextMeshProUGUI>();
        _Sprite.fillAmount = 1;
        _CurrentTime = _TimeForARound + 1;

        _Time.text = "" + _CurrentTime + "";
        _Time2.text = _Time.text;
        _IsEndGame = false;
    }
   
    // Update is called once per frame
    void Update()
    {
        if (_Time != null && _CurrentTime != 0)
        {
            _CurrentTime = Mathf.Clamp(_CurrentTime -= Time.deltaTime, 0, _TimeForARound + 1);
            _Sprite.fillAmount = _CurrentTime/31;
            _Time.text = "" + (int)_CurrentTime + "";
            _Time2.text = _Time.text;
        }
        if (_CurrentTime == 0 && _IsEndGame == false) 
        { 
            EndTimer?.Invoke();
            _EndMenu._EndTime();
          _IsEndGame=true;
        }
    }
}
