using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scoring : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _TextPlayerScore, _TextPlayerScore2;
  

    [SerializeField] private float _ScoringToReach;
    [SerializeField] private float _ScoringOfThePlayer;


    private bool _IsTheGameIsOnPause = false;

    void Start()
    {
        //_TextScoreToReach.text = _ScoringToReach.ToString();
       
      
        _TextPlayerScore.text = _ScoringOfThePlayer.ToString();
        _TextPlayerScore2.text = _TextPlayerScore.text;
        //_TextScoreToReach2.text = _TextScoreToReach.text;
    }
    public void UpdateThePlayerScore(float Score)
    {
        if(!_IsTheGameIsOnPause){ 
        _ScoringOfThePlayer += Score;    
        _TextPlayerScore.text = _ScoringOfThePlayer.ToString();
            _TextPlayerScore2.text = _TextPlayerScore.text;
        }
    }
    public float GiveTheScore(float score )
    {
        score = _ScoringOfThePlayer;
        return score;
    }
    public void Pause_Unpause(bool PauseOrNot)
    {
        _IsTheGameIsOnPause = PauseOrNot;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
