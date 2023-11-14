using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    [SerializeField] private AudioSource _Audio;

    [SerializeField] private List<float> _Score = new List<float>();
    private Multiplier _ScriptMultiplier;
    private Timer _Timer;
    private Scoring _Scoring;

    private bool _EndGame;
    [SerializeField] private GameObject FirstbuttonPauseMenu, FirstButtonOptionMenu, _PauseMenu, FirstEndButton, _EndMenu;
    [SerializeField] private List<GameObject> _Button = new List<GameObject>();
    [SerializeField] private List<GameObject> _Menu = new List<GameObject>();

    [Header("BeforeGame")]
    private bool _BeforeGame;
    [SerializeField] private GameObject _BeforeGameMenu;
    private void Awake()
    {
        _BeforeGame = true;
        _EndGame = false;
        _Timer = GetComponentInChildren<Timer>();
        _EndMenu.SetActive(false);
        _PauseMenu.SetActive(false);
        _Scoring = GetComponentInChildren<Scoring>();
        _ScriptMultiplier = GetComponentInChildren<Multiplier>();

    }
    #region ChangementdeLevel
    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsync(sceneIndex));

        Time.timeScale = 1;
    }
    IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        // SceneManager.LoadScene(4, LoadSceneMode.Additive);

        yield return null;

    }
    #endregion

    #region Option
    public void OpenOptionMenu()
    {
        EventSystem.current.SetSelectedGameObject(null);
      //  EventSystem.current.SetSelectedGameObject(FirstButtonOptionMenu);

    }

    public void CloseOptionMenu()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(FirstbuttonPauseMenu);
    }
    #endregion

    #region Resume/Pause Time

    private void Endtime()
    {
        _BeforeGameMenu.SetActive(false);   
        Time.timeScale = 0.0f;
        _Scoring.Pause_Unpause(true);
        _Audio.Pause();
        _EndGame = true;
        _EndMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
      //  EventSystem.current.SetSelectedGameObject(FirstEndButton);
    }

    private void PauseGame()
    {
        Time.timeScale = 0.0f;
        _Scoring.Pause_Unpause(true);
        _Audio.Pause();

        _PauseMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
       
        
    }
    public void Unpause()
    {
        Time.timeScale = 1.0f;
        _Scoring.Pause_Unpause(false);
        foreach (var item in _Menu)
        {
            item.SetActive(false);
        }
        _Audio.Play();
        _PauseMenu.SetActive(false);

    }

    public void PutInPause()
    {
        if (Time.timeScale == 1)
        {
           PauseGame();
          
        }
        else
        {
            Unpause();
        }
    }
    #endregion

    #region Event Static
    private void OnEnable()
    {
        FindTheRythm.PlayerisInTheRythm += PlayerInTheRythm;
        FindTheRythm.PlayerLoseTheRythm += PlayerLoseRythm;
        // BatTouch.PlayerisInTheRythm += ScoringForThePlayer;
        BReakObjetct.GiveTheSizeForScoring += Scoring;
        Timer.EndTimer += Endtime;
    }
    private void OnDisable()
    {
        FindTheRythm.PlayerisInTheRythm -= PlayerInTheRythm;
        FindTheRythm.PlayerLoseTheRythm -= PlayerLoseRythm;
        // BatTouch.PlayerisInTheRythm += ScoringForThePlayer;
        BReakObjetct.GiveTheSizeForScoring -= Scoring;
        Timer.EndTimer -= Endtime;
    }

    private void Scoring(string Size)
    {

        _Scoring.UpdateThePlayerScore(CheckTheSize(Size) * _ScriptMultiplier.CurrentMultiplier());
        // Debug.Log(CheckTheSize(Size));
    }
    public float WhatToShow(string Size)
    {
        float Score = CheckTheSize(Size) * _ScriptMultiplier.CurrentMultiplier();

        return Score;
    }
    /*  private void ScoringForThePlayer(string Size)
      {
          Debug.Log(Size);

          _Scoring.UpdateThePlayerScore(CheckTheSize(Size) * _ScriptMultiplier.CurrentMultiplier());
          Debug.Log(CheckTheSize(Size));
      }*/
    public float CheckTheSize(string Size)
    {
        float Score = 0;
        switch (Size)
        {
            case "A":
                Score = _Score[0] / 2;
                break;
            case "P":
                Score = _Score[0];
                break;
            case "M":
                Score = _Score[1];
                break;
            case "G":
                Score = _Score[2];
                break;

            default:
                break;
        }

        return Score;
    }

    private void PlayerLoseRythm()
    {
        _ScriptMultiplier.LostYourMultiplie();

    }

    private void PlayerInTheRythm()
    {
        _ScriptMultiplier.ActiveMultiplicateur();
    }
    #endregion

    public void StartTheGame()
    {
        _BeforeGame = false;
    }

    private void SelectedObject()
    {

        if (EventSystem.current.currentSelectedGameObject == null)
        {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {

                int ActuelMenu = 0;
                foreach (var item in _Menu)
                {
                    if (item.activeSelf == true)
                    {
                        ActuelMenu = _Menu.IndexOf(item);
                    }
                }
                EventSystem.current.SetSelectedGameObject(_Button[ActuelMenu]);
            }
        }


    }
    private void Update()
    {
        if (Input.GetButtonDown("Cancel") && _EndGame == false)
        {
            if (_BeforeGame == false)
            { _BeforeGameMenu.SetActive(false);
               PutInPause();

            }
          
        }
        
        if (Time.timeScale == 0)
        {
            SelectedObject();
        }
     

    }


}
