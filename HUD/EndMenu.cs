using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndMenu : MonoBehaviour
{

    private float _Score;
    [SerializeField] private List<float> _Palier = new List<float>();
    [SerializeField] private Scoring _ScriptScore;
    [SerializeField] private TextMeshProUGUI _ScoreText1, _ScoreText2, _TextForTheplayer1, _TextForThePlayer2;
   
   
    public void _EndTime()
    {
        _Score= _ScriptScore.GiveTheScore(_Score);
        CheckTheScoreForTheText(_Score);

        _ScoreText1.text = _Score.ToString();
        _ScoreText2.text = _ScoreText1.text;
        Debug.Log("Here");
    }

    public void CheckTheScoreForTheText(float score)
    {
        
        if (score > _Palier[0])
        {
            _TextForTheplayer1.text = " You are the Beat Master";
            _TextForThePlayer2.text = _TextForTheplayer1.text;
            return;
        }
        if (score > _Palier[1])
        {
            _TextForTheplayer1.text = "You are feeling the Beat";
            _TextForThePlayer2.text = _TextForTheplayer1.text;
            return;
        }
        if (score > _Palier[2])
        {
            _TextForTheplayer1.text = "You broke the beat ";
            _TextForThePlayer2.text = _TextForTheplayer1.text;
            return;
        }
        if (score > _Palier[3])
        {

            _TextForTheplayer1.text = "It's Difficult To be In Rythm";
            _TextForThePlayer2.text = _TextForTheplayer1.text;
            return;
        }
        if (score > _Palier[4])
        {
            _TextForTheplayer1.text = "Put your music On ";
            _TextForThePlayer2.text = _TextForTheplayer1.text;
            return;
        } else
        {
            _TextForTheplayer1.text = "Did you forget to hit ?";
            _TextForThePlayer2.text = _TextForTheplayer1.text;


            return;
        }
        

    }
  


}
