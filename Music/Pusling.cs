using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusling : MonoBehaviour
{
    private bool _IsInPulsig;
    public float _speed;
    public float MaxPulse;
    private Vector3 initialPulse;


    private void Start()
    {

        _IsInPulsig = false;
       initialPulse = transform.localScale;
    }
    public void Pulsing()
    {
        transform.localScale = new Vector3(MaxPulse,MaxPulse,MaxPulse);
        _IsInPulsig = true;
    }
    // Update is called once per frame
    void Update()
    {
        if(_IsInPulsig) 
        {

            transform.localScale = Vector3.Lerp(transform.localScale, initialPulse, Time.deltaTime * _speed);
            
        }



    }
}
