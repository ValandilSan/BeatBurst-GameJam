using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BeatTempo : MonoBehaviour
{
    public float _bpm;
    public AudioSource _source;
    public Intervals[] _Intervals;

    private void Update()
    {
         foreach (var interval in _Intervals) 
        { 
            float sampledTime = (_source.timeSamples / (_source.clip.frequency * interval.GetIntervalLenght(_bpm)));
            interval.CheckForNewInterval(sampledTime);
        
        }
    }



}

[System.Serializable]
public class Intervals
{
    public float _steps;
    public UnityEvent _event;
    private int _LastIntverlal;
    public float GetIntervalLenght(float bpm)
    {
        return 60f/ (bpm*_steps);
    }

    public void CheckForNewInterval(float intervel)
    {
        if (Mathf.FloorToInt(intervel) != _LastIntverlal)
        {
            _LastIntverlal = Mathf.FloorToInt(intervel);
            _event.Invoke();
        }
    }
}
