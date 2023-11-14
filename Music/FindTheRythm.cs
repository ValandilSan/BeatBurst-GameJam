using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindTheRythm : MonoBehaviour
{
    public delegate void PlayerRythmEvent();
    public static event PlayerRythmEvent PlayerisInTheRythm;
    public static event PlayerRythmEvent PlayerLoseTheRythm;
   


    public int WhereTheMusicBeginInSeconds;
    public AudioSource PlaySound;
    public float MargeClic;
    public BatTouch _Bat;


    public Attack _Playerattack;
    private bool _IsRythm;
    private bool _IsTouchSomething;
    private Coroutine _TimeWhenThePlayerCanClick;
    private void Start()
    {
        _IsRythm = false;
        PlaySound.time = WhereTheMusicBeginInSeconds;
        PlaySound.Play();
        //InvokeRepeating("CreerNote", 2.0f,1.0f);
    }



    IEnumerator TimeForClick()
    {
        _IsRythm = true;
        
        yield return new WaitForSeconds(MargeClic);
        
        _IsRythm = false;
        _TimeWhenThePlayerCanClick = null;
        Debug.Log(_IsRythm);

    }
    public void CreerNote()
    {
        // Debug.Log("Hello");
        if (_TimeWhenThePlayerCanClick != null)
        {
            StopCoroutine( _TimeWhenThePlayerCanClick );
            _TimeWhenThePlayerCanClick = null;
            _IsRythm = false;

           
            _TimeWhenThePlayerCanClick = StartCoroutine(TimeForClick());
            return;
        }
        _TimeWhenThePlayerCanClick = StartCoroutine(TimeForClick());
     
    }
   


    public void LoseRythm()
    {
        PlayerLoseTheRythm?.Invoke();
    }

    public void StayInRythm()
    {
        PlayerisInTheRythm?.Invoke();
    }
    public void CheckTheRythm()
    {
     
        if (Time.timeScale != 0 )
        {
            if (_IsRythm )
            {
                _Bat.IsInRythm(true);
               // Debug.Log("InRythm");
            }

            else
            {
                
                PlayerLoseTheRythm?.Invoke();
                _Bat.IsInRythm(false);
               // Debug.Log("NotInRythm");
            }

        }
       
    }
    private void Update()
    {
        
      
    }
}
