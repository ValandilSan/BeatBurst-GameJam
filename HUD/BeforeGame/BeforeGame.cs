using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeforeGame : MonoBehaviour
{
    [SerializeField] private GameObject _DuringGame;
    [SerializeField] private GameObject _BeforeGame;
    [SerializeField] private float _TimeBeforeGo,_speed;
    [SerializeField] HUD _HUDScript;
    private bool _WaitBeforeGo;
    private void Awake()
    {
        _BeforeGame.SetActive(true);
        _WaitBeforeGo = true;
        Time.timeScale = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
      
    }

    private void Update()
    {
        if(_WaitBeforeGo)
        {
            _TimeBeforeGo = Mathf.Clamp(_TimeBeforeGo -= (( Time.unscaledDeltaTime-Time.unscaledDeltaTime)+0.1f ) * _speed, 0, _TimeBeforeGo);
            if (_TimeBeforeGo == 0)
            {
                Time.timeScale = 1;
                _WaitBeforeGo= false;
                _HUDScript.StartTheGame();

            }
        }
       

    }

}
